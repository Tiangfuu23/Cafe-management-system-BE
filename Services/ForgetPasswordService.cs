using Entities.Configuration;
using Services.Contracts;
using Entities.MessageDetail;
using MimeKit;
using MailKit.Net.Smtp;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Shared.DataTransferObjects;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Bcpg;
namespace Services
{
    internal class ForgetPasswordService : IForgetPasswordService
    {
        private readonly EmailConfiguration _emailConfig;
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IConfiguration _configuration;
        public ForgetPasswordService(IRepositoryManager repository, EmailConfiguration emailConfig, ILoggerManager logger, IConfiguration config)
        {
            _emailConfig = emailConfig;
            _logger = logger;
            _repository = repository;
            _configuration = config;
        }

        public int handleForgetPassword(ForgetPasswordDto forgetPassword)
        {
            var userEntity = _repository.RepositoryUser.GetUser(forgetPassword.username, trackChange: false);

            if (userEntity == null) throw new UserNotFoundException(forgetPassword.username);

            if (userEntity.email != forgetPassword.email) throw new EmailNotMatchException(forgetPassword.username);

            var otpCode = getRandomCode();
            var otpCodeEntity = new OtpCode
            {
                code = otpCode,
                creationDate = DateTime.UtcNow,
                userId = userEntity.userId,
            };
            _repository.RepositoryOtpCode.CreateOtpCode(otpCodeEntity);
            _repository.Save();
            MessageDetails message = new MessageDetails(new string[] {userEntity.email}, "Yêu cầu khôi phục mật khẩu", 
                                                    $"Mã xác thực khôi phục mật khẩu: {otpCode}", userEntity.fullname ?? "");

            SendEmail(message);

            return otpCodeEntity.id;
        }

        public User authenticateOtpCode(OtpCodeForValidationDto otpCodeForValid)
        {
            var OtpCodeConfig = _configuration.GetSection("OtpCodeConfiguration");

            var otpCodeEntity = _repository.RepositoryOtpCode.getOtpCode(otpCodeForValid.otpCodeId, trackChange: true);

            if (otpCodeEntity == null) throw new OptCodeNotFoundException(otpCodeForValid.otpCodeId);

            var otpCodeEntitiesList = _repository.RepositoryOtpCode.getOtpCodeByUserId(otpCodeEntity.userId, trackChange: false);
            var lastOtpCodeInList = otpCodeEntitiesList.LastOrDefault();

            var currentTime = DateTime.UtcNow;

            if ( (lastOtpCodeInList != null && otpCodeEntity.id != lastOtpCodeInList.id) || otpCodeEntity.used || currentTime.Subtract(otpCodeEntity.creationDate).TotalMinutes > OtpCodeConfig.GetValue<double>("lifetime") ) 
                throw new OtpCodeExpiredException();

            if (otpCodeEntity.attempsCnt + 1 > OtpCodeConfig.GetValue<int>("attemptAllow"))
                throw new ExceedAttempsAllowedOtpCodeException();

            if (otpCodeForValid.code != otpCodeEntity.code)
            {
                otpCodeEntity.attempsCnt += 1;
                _repository.Save();
                throw new IncorrectOtpCodeException();

            }

            otpCodeEntity.used = true;
            _repository.Save();

            var userEntity = _repository.RepositoryUser.GetUser(otpCodeEntity.userId, trackChange: false);

            return userEntity;
        }

        private void SendEmail(MessageDetails message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(MessageDetails message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.SenderName ,_emailConfig.SenderEmail));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                    client.Send(mailMessage);
                }
                catch
                {
                    //"log an error message or throw an exception or both."
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
            
        }
        private string getRandomCode() {
            var chars = "0123456789";
            var randomCode = new char[5];
            var random = new Random();

            for (int i = 0; i < randomCode.Length; i++)
            {
                randomCode[i] = chars[random.Next(chars.Length)];
            }

            return new String(randomCode);

        }
    }
}

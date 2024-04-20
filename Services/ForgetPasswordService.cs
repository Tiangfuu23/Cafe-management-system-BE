using Entities.Configuration;
using Services.Contracts;
using Entities.MessageDetail;
using MimeKit;
using MailKit.Net.Smtp;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Exceptions;
namespace Services
{
    internal class ForgetPasswordService : IForgetPasswordService
    {
        private readonly EmailConfiguration _emailConfig;
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        public ForgetPasswordService(IRepositoryManager repository, EmailConfiguration emailConfig, ILoggerManager logger)
        {
            _emailConfig = emailConfig;
            _logger = logger;
            _repository = repository;
        }

        public bool handleForgetPassword(ForgetPasswordDto forgetPassword)
        {
            var userEntity = _repository.RepositoryUser.getUser(forgetPassword.username, trackChange: true);

            if (userEntity == null) throw new UserNotFoundException(forgetPassword.username);

            if (userEntity.email != forgetPassword.email) return false;

            var newPassword = getRandomPassword();

            userEntity.password = newPassword;

            _repository.Save();

            MessageDetails message = new MessageDetails(new string[] {userEntity.email}, "Yêu cầu khôi phục mật khẩu", 
                                                    $"Mật khẩu của bạn đã khôi phục thành: {newPassword}", userEntity.fullname ?? "");

            SendEmail(message);
            return true;
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
        private string getRandomPassword() {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var randomPassword = new char[8];
            var random = new Random();

            for (int i = 0; i < randomPassword.Length; i++)
            {
                randomPassword[i] = chars[random.Next(chars.Length)];
            }

            return new String(randomPassword);

        }
    }
}

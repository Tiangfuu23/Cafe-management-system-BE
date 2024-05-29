using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Entities.Configuration;
using Entities.DataTransferObjects;
using Shared.DataTransferObjects;
namespace Presentation.Controllers
{
    [Route("ForgetPassword")]
    [ApiController]
    public class ForgetPasswordController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly EmailConfiguration _emailConfiguration;
        public ForgetPasswordController(IServiceManager serviceManager, EmailConfiguration emailConfig)
        {
            _service = serviceManager;
            _emailConfiguration = emailConfig;
        }
  
        [HttpPost]
        public IActionResult ForgetPassword([FromBody] ForgetPasswordDto forgetPassword)
        {
            var otpCodeId = _service.ForgetPasswordService.handleForgetPassword(forgetPassword);
            return Ok(new { otpCodeId });
        }

        [HttpPost]
        [Route("OtpCode")]
        public IActionResult ValidateOtpCode([FromBody] OtpCodeForValidationDto otpCodeForValidation)
        {
            var user = _service.ForgetPasswordService.authenticateOtpCode(otpCodeForValidation);
            var token = _service.LoginService.CreateToken(user);
            return Accepted(new { message = "Xác thực thành công!", token, user.userId });
        }
    }
}

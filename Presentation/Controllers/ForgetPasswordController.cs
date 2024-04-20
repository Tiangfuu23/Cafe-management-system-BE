using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Entities.Configuration;
using Entities.DataTransferObjects;
using Entities.MessageDetail;
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

            var success = _service.ForgetPasswordService.handleForgetPassword(forgetPassword);
            if (!success)
            {
                return Conflict(new { message = $"Email không chính xác!" });
            }
            return Ok();
        }
    }
}

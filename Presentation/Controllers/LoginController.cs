using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Entities.DataTransferObjects;

namespace Presentation.Controllers
{
    [Route("Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public LoginController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserForAuthenticationDto userforAuth)
        {
            var userInDb = _serviceManager.LoginService.ValidateUSer(userforAuth);
            if (!userInDb)
            {
                return Unauthorized();
            }
            return Ok(new {token = _serviceManager.LoginService.CreateToken() });
        }
    }
}

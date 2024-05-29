using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;

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
            var result = _serviceManager.LoginService.ValidateUSer(userforAuth);
            var userDto = result.Item1 as UserDto;
            var tokenDto = result.Item2 as TokenDto;
            return Ok(new {user = userDto,  tokenDto.token });
        }

        [Route("Validate")] 
        [HttpPost]
        [Authorize]
        public IActionResult LoginValidate()
        {
            // if reach here -> token is valid
            return Ok(true);
        }
    }
}

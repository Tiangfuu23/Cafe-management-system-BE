using Microsoft.AspNetCore.Mvc;
using Contracts;
using Entities.DataTransferObjects;
using Services.Contracts;
using Microsoft.AspNetCore.Authorization;
namespace Presentation.Controllers {

    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IServiceManager _serviceManager;
        public UserController(ILoggerManager logger, IServiceManager serviceManager)
        {
            _logger = logger;
            _serviceManager = serviceManager;
        }

        [HttpGet(Name = "GetUsers")]
        [Authorize]
        public IActionResult GetUsers()
        {
           var userDtoList = _serviceManager.UserService.GetAllUsers(trackChange: false);

            return Ok(userDtoList);
        }


        [HttpPost]
        public IActionResult Register([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            var success = _serviceManager.UserService.Register(userForRegistrationDto);

            if (!success) return BadRequest();
            return StatusCode(201,new {message = "Thêm mới thành công"});
        }

        [Route("{id:int}")]
        [HttpPut]
        [Authorize]
        public IActionResult UpdateUser(int id, [FromBody] UserForUpdateDto userForUpdate)
        {
            _serviceManager.UserService.UpdateUser(id, userForUpdate);

            return Ok(new { message = "Cập nhật người dùng thành công!" });
        }

        [Route("{id:int}/UpdatePassword")]
        [HttpPut]
        [Authorize]
        public IActionResult UpdatePassword(int id, [FromBody] PasswordForUpdateDto passwordForUpdate) 
        {
            _serviceManager.UserService.UpdatePassword(id, passwordForUpdate);
            return Ok(new {message = "Cập nhật mật khẩu thành công!"});
        }

        [Route("{id:int}")]
        [HttpGet]
        [Authorize]
        public IActionResult GetUser(int id)
        {
            var userDto = _serviceManager.UserService.GetUser(id, trackChange: false);
            return Ok(userDto);
        }
    }
}

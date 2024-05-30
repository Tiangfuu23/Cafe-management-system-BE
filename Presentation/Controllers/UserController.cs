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
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult GetUsers()
        {
           var userDtoList = _serviceManager.UserService.GetAllUsers(trackChange: false);

            return Ok(userDtoList);
        }


        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Register([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            var id = _serviceManager.UserService.Register(userForRegistrationDto);

            return StatusCode(201,new {message = "Thêm mới thành công", id});
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

        [Route("{id:int}/Active")]
        [HttpPut]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult activeUser(int id)
        {
            _serviceManager.UserService.UpdateUserActiveState(id, true);
            return Ok(new { message = "Cập nhật thành công" });
        }

        [Route("{id:int}/Inactive")]
        [HttpPut]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult inactiveUser(int id)
        {
            _serviceManager.UserService.UpdateUserActiveState(id, false);
            return Ok(new { message = "Cập nhật thành công" });
        }

        [Route("{id:int}/Bill")]
        [HttpGet]
        [Authorize]
        public IActionResult GetBillsByUserId(int id)
        {
            var billDtoList = _serviceManager.BillService.GetAllBills(trackChange: false).Where(p => p.user.id == id);
            return Ok(billDtoList);
        }
    }
}

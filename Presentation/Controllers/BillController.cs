using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.DataTransferObjects;
using System.Runtime.CompilerServices;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("Bill")]
    [Authorize]
    public class BillController : ControllerBase
    {
        private readonly IServiceManager _service;
        public BillController(IServiceManager service)
        {
            _service = service;
        }


        [HttpPost]
        public IActionResult CreateBill(BillForCreationDto billForCreation)
        {
            var res = _service.BillService.CreateBill(billForCreation);

            if(!res.Item1) return BadRequest(new {message = res.Item2}); 

            return StatusCode(201, new 
            {
                message = "Thêm mới thành công",
                id = res.Item3
            });
        }

        [HttpGet]
        public IActionResult GetAllBills()
        {
            var billEntitiesDto = _service.BillService.GetAllBills(trackChange: false);
            return Ok(billEntitiesDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteBill(int id)
        {
            _service.BillService.DeleteBill(id);
            return Ok(new { message = "Xóa thành công" });
        }
    }
}

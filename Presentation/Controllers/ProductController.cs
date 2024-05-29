using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.DataTransferObjects;

namespace Presentation.Controllers
{
    [Route("Product")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _services;
        public ProductController(IServiceManager service)
        {
            _services = service;
        }

        [HttpPost]
        public IActionResult createProduct([FromBody] ProductForCreationDto productForCreation)
        {
            int id = _services.ProductService.CreateProduct(productForCreation);

            return StatusCode(201, new {message = "Thêm mới thành công!", id});
        }

        [HttpGet]
        public IActionResult getAllProducts()
        {
            var productsDtoList = _services.ProductService.GetAllProducts(false);
            return Ok(productsDtoList);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult getProduct(int id)
        {
            var productDto = _services.ProductService.GetProduct(id, trackChange: false);
            return Ok(productDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult updateProduct(int id, [FromBody] ProductForUpdateDto productForUpdateDto)
        {
            if (id != productForUpdateDto.id) return BadRequest("Id in route is not the same as id in payload!");
            _services.ProductService.UpdateProduct(productForUpdateDto);
            return Ok(new { message = "Cập nhật thành công" });
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult deleteProduct(int id)
        {
            _services.ProductService.DeleteProduct(id);
            return Ok(new { message = "Xóa thành công" });
        }

        [HttpPut]
        [Route("{id:int}/Enable")]
        public IActionResult enableProduct(int id)
        {
            _services.ProductService.UpdateProductStatus(id, newStatus: true);
            return Ok(new { message = "Cập nhật thành công" });
        }

        [HttpPut]
        [Route("{id:int}/Disable")]
        public IActionResult disableProduct(int id)
        {
            _services.ProductService.UpdateProductStatus(id, newStatus: false);
            return Ok(new { message = "Cập nhật thành công" });
        }
    }
}

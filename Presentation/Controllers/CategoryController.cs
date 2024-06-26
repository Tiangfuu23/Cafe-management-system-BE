﻿

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.DataTransferObjects;

namespace Presentation.Controllers
{
    [Route("Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CategoryController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public IActionResult getCategories()
        {
            var categoriesDtoList = _service.CategoryService.getAllCategory(false);
            return Ok(categoriesDtoList);
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult getCategory(int id)
        {
            var categoryDto = _service.CategoryService.getCategoryById(id, false);

            return Ok(categoryDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult createCategory([FromBody] CategoryForCreationDto categoryForCreation)
        {
            int id = _service.CategoryService.createCategory(categoryForCreation);
            return StatusCode(201, new { message = "Thêm mới thành công", id });
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult updateCategory(int id, [FromBody] CategoryForUpdateDto categoryForUpdate)
        {
            if (id != categoryForUpdate.id)
            {
                return BadRequest(new { message = "Không thể thay đổi khóa của category!" });
            }
            _service.CategoryService.updateCategory(id, categoryForUpdate);
            return Ok(new { message = "Cập nhật thành công" });
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult deleteCategory(int id)
        {
            _service.CategoryService.deleteCategory(id);
            return Ok(new { message = "Xóa category thành công" });
        }

        [HttpGet]
        [Route("{id:int}/Product")]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult getProductsByCategoryId(int id)
        {
            var productsDtoList = _service.CategoryService.getProductsByCategoryId(id, trackChange: false);
            return Ok(productsDtoList);
        }

        [Route("Checktoken")]
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult CheckToken()
        {
            return Ok();
        }
    }
}

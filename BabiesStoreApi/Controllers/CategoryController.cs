using BabiesStoreApi.Dtos;
using BabiesStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BabiesStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService = new CategoryService();

        [HttpPost("create")]
        public IActionResult CreateCategory([FromBody] CategoryDto categoryDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                bool isCreated = _categoryService.AddCategory(categoryDto);

                if (!isCreated)
                    return StatusCode(500, "Failed to create category");

                return Ok("Category created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

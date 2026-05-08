using Application.Users.Transactions.Categories_A;
using Application.Users.Transactions.CategoriesDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAp_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplication _categoryApplication;

        public CategoryController(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateCategoryDto dto)
        {
            await _categoryApplication.Create(dto);
            return Ok("Category created successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryApplication.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoryApplication.GetById(id);
            if (result == null)
                return NotFound("Category not found");
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateUpdateCategoryDto dto)
        {
            try
            {
                await _categoryApplication.Update(id, dto);
                return Ok("Category updated successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryApplication.Delete(id);
                return Ok("Category deleted successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

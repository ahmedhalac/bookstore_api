using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;


namespace BookStore_API.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // Get: api/GetCategory
        [HttpGet("GetCategories")]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            List<Category> categories = await _categoryRepository.GetAll();
            return Ok(categories);
        }

        // Get: api/GetCategory/1
        [HttpGet("GetCategory/{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryRepository.Get(id);
            if(category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // Post: api/AddCategory
        [HttpPost("AddCategory")]
        public async Task<ActionResult<Category>> AddCategory(Category category)
        {
            var addedCategory = await _categoryRepository.Add(category);
            return CreatedAtAction("GetCategories", new { id = addedCategory.Id }, addedCategory);
        }

        // Delete: api/DeleteCategory
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromQuery] int id)
        {
            var category = await _categoryRepository.Delete(id);
            if(category == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // Put: api/UpdateCategory/1
        [HttpPut("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] Category obj, int id)
        {
            var category = await _categoryRepository.Get(id);
            if(category == null)
            {
                return BadRequest();
            }

            category.Name = obj.Name;
            category.DisplayOrder = obj.DisplayOrder;

            await _categoryRepository.Update(category);

            return NoContent();
        }
    }
}


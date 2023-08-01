using BookStore_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BookStore_API.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly Data.ApplicationDbContext _db;
        public CategoryController(Data.ApplicationDbContext db)
        {
            _db = db;
        }

        // Get: api/GetCategory
        [HttpGet("GetCategories")]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            List<Category> categories = await _db.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("GetCategory/{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _db.Categories.FindAsync(id);
            return Ok(category);
        }

        // Post: api/AddCategory
        [HttpPost("AddCategory")]
        public async Task<ActionResult<Category>> AddCategory(Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            return CreatedAtAction("GetCategories", new { id = category.Id }, category);
        }

        // Delete: api/DeleteCategory
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromQuery] int id)
        {
            var category = await _db.Categories.FindAsync(id);
            if(category == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] Category obj, int id)
        {
            var category = await _db.Categories.FindAsync(id);
            if(category == null)
            {
                return BadRequest();
            }

            category.Name = obj.Name;
            category.DisplayOrder = obj.DisplayOrder;

            _db.Categories.Update(category);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BookStore_API.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly Data.ApplicationDbContext _context;
        public CategoryController(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        //Get: api/categories
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        //tbd
    }
}


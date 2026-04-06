using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCrud.Data;
using SimpleCrud.Models;

namespace SimpleCrud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _context.Categories.Take(10).ToListAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null) return NotFound("القسم غير موجود");

            return Ok(category);
        }


        [HttpPost]
        public ActionResult<Category> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public IActionResult EditCategory(int id, Category category)
        {
            if (id != category.Id) return BadRequest("ID mismatch");

            var existingCategory = _context.Categories.Find(id);
            if (existingCategory == null) return NotFound();

            existingCategory.Title = category.Title;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Include(c => c.Products).FirstOrDefault(c => c.Id == id);

            if (category == null) return NotFound();

            if (category.Products.Any())
            {
                return BadRequest("لا يمكن مسح القسم لأنه يحتوي على منتجات مرتبطة به.");
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

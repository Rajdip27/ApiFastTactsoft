using ApiFastTactsoft.DatabaseContext;
using ApiFastTactsoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace ApiFastTactsoft.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
      private readonly   ApplicationDbContext _dbContext;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAll()
        {
            return (await _dbContext.Categories.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var Result=await _dbContext.Categories.FindAsync(id);
                return Result ==null?NotFound():Ok(Result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            try
            {
                await _dbContext.Categories.AddAsync(category);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = category.CategoryId }, category);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            try
            {
                if (id != category.CategoryId)
                {
                    return NotFound();
                }
                _dbContext.Entry(category).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var Result=await _dbContext.Categories.FindAsync(id);
                if (Result == null)
                {
                    return NotFound();
                }
                _dbContext.Entry(Result).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

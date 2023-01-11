using ApiFastTactsoft.DatabaseContext;
using ApiFastTactsoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiFastTactsoft.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public PostController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpGet]
        public async Task<IEnumerable<Post>> Get()
        {
            return await _dbContext.post.ToListAsync();
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var Result=await _dbContext.post.FindAsync(id);
                return Result==null ?NotFound():Ok(Result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create( Post pt)
        {
            try
            {
                pt.CreatedDate = DateTime.Now;
                await _dbContext.post.AddAsync(pt);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = pt.Id }, pt);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id ,Post pt)
        {
            try
            {
                if (id != pt.Id) return BadRequest();
               _dbContext.Entry(pt).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pt = await _dbContext.post.FindAsync(id);
                if(pt== null) return BadRequest();
                _dbContext.post.Remove(pt);
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

using ApiFastTactsoft.DatabaseContext;
using ApiFastTactsoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiFastTactsoft.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _dbContext.customer.ToListAsync();
        }
        [HttpPut("id")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var ct = await _dbContext.customer.FindAsync(id);
                return ct == null ? NotFound() : Ok(ct);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }



        [HttpPost]
        public async Task<IActionResult> Create(Customer ct)
        {
            try
            {
                await _dbContext.AddRangeAsync(ct);
                await _dbContext.SaveChangesAsync();
                //return CreatedAtAction(nameof(GetById), new {id==customer.Id});
                return CreatedAtAction(nameof(GetById), new { id = ct.Id }, ct);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, Customer ct)
        {
            try
            {
                if (id != ct.Id) return BadRequest();
                _dbContext.Entry(ct).State = EntityState.Modified;
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
                var ct=await _dbContext.customer.FindAsync(id);
                if(ct==null) return BadRequest();
                _dbContext.customer.Remove(ct);
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

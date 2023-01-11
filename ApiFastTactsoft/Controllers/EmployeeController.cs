using ApiFastTactsoft.DatabaseContext;
using ApiFastTactsoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiFastTactsoft.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
      private readonly  ApplicationDbContext _dbContext;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _dbContext.Employees.ToListAsync();
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById( int id)
        {
            try
            {
                var Result=await _dbContext.Employees.FindAsync(id);
                //if (Result == null) return NotFound();
                return Result == null ? NotFound() : Ok(Result);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            try
            {
                await _dbContext.Employees.AddAsync(employee);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = employee.EmployeeId }, employee);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(int id,Employee employee)
        {
            try
            {
                var Result = await _dbContext.Employees.FindAsync(id);
                if(Result == null) return NotFound();
                _dbContext.Entry(employee).State = EntityState.Modified;
                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var Result=await _dbContext.Employees.FindAsync(id);
                if (Result == null) return NotFound();
                _dbContext.Employees.Remove(Result);
                await _dbContext.SaveChangesAsync();
                return NoContent();

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

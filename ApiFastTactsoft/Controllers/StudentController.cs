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
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentController(ApplicationDbContext dbContext)
        {
            _dbContext=dbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            return await _dbContext.students.ToListAsync();
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var st = await _dbContext.students.FindAsync(id);
                return st == null ? NotFound() : Ok(st);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }


        }
        [HttpPost]
        public async Task<IActionResult> Create(Student st)
        {
            try
            {
                await _dbContext.students.AddAsync(st);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = st.Id }, st);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            
            }
            
        }
        [HttpPut("Id")]
        public async Task<IActionResult> Update(int Id, Student student)
        {
            try
            {
                if(Id!=student.Id) return BadRequest();
                _dbContext.Entry(student).State = EntityState.Modified;
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
                var st = await _dbContext.students.FindAsync(id);
                if(st==null) return BadRequest();
                _dbContext.students.Remove(st);
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

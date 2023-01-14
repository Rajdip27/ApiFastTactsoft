using ApiFastTactsoft.DatabaseContext;
using ApiFastTactsoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiFastTactsoft.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
             
            return await _dbContext.Users.ToListAsync();
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var Result= await _dbContext.Users.FindAsync(id);
            return Result==null ?NotFound():Ok(Result);
           
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction (nameof(GetById), new {id=user.Id}, user);

        }
        [HttpPut]
        public async Task<IActionResult> Update(int id,User user)
        {
            if (id != user.Id) return NotFound();
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result=await _dbContext.Users.FindAsync(id);
            if(result==null) return NotFound();
            _dbContext.Entry(result).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}

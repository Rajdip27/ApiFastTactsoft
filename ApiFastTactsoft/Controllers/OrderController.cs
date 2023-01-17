using ApiFastTactsoft.DatabaseContext;
using ApiFastTactsoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiFastTactsoft.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
      private readonly  ApplicationDbContext _dbContext;
        public OrderController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        [HttpGet]
        public async  Task<IEnumerable<Order>> GetAll()
        {
            return await _dbContext.Orders.ToListAsync();
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if(id == null)
                {
                    return NotFound();
                }
                var order = await _dbContext.Orders.FindAsync(id);
                return order == null ? NotFound() : Ok(order);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            try { 
                await _dbContext.Orders.AddAsync(order);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction (nameof(GetById), new {id=order.Id},order);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            try
            {
                if (id != order.Id)
                {
                    return NotFound();
                }
                _dbContext.Entry(order).State = EntityState.Modified;
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
                var order = await _dbContext.Orders.FindAsync(id);
                if(order == null)
                {
                    return NotFound();
                }
                _dbContext.Entry(order).State = EntityState.Deleted;
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

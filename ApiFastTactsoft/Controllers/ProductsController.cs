using ApiFastTactsoft.DatabaseContext;
using ApiFastTactsoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiFastTactsoft.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<Products>> Get()
        {
            return await _dbContext.products.ToListAsync();
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _dbContext.products.FindAsync(id);
                return product == null ? NotFound() : Ok(product);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(Products products)
        {
            try
            {
                await _dbContext.AddAsync(products);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = products.Id }, products);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update( int id,Products products)
        {
            try
            {
                if (id != products.Id) return NotFound();
                _dbContext.Entry(products).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return NoContent();



            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete( int id)
        {
            try
            {
                var Result = await _dbContext.products.FindAsync(id);
                if(Result == null) return NotFound();
                _dbContext.products.Remove(Result);
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

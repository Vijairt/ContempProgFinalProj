using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamWebAPI.Data;
using TeamWebAPI.Models;

namespace TeamWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BreakfastFoodsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BreakfastFoodsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BreakfastFoods
        // GET: api/BreakfastFoods/5
        // If id is null or 0, returns the first 5 records
        [HttpGet("{id?}")]
        public async Task<ActionResult<IEnumerable<BreakfastFood>>> Get(int? id)
        {
            if (id == null || id == 0)
            {
                var first5 = await _context.BreakfastFoods.Take(5).ToListAsync();
                return Ok(first5);
            }

            var food = await _context.BreakfastFoods.FindAsync(id);
            if (food == null)
                return NotFound($"BreakfastFood with ID {id} was not found.");

            return Ok(new List<BreakfastFood> { food });
        }

        // POST: api/BreakfastFoods
        [HttpPost]
        public async Task<ActionResult<BreakfastFood>> Create(BreakfastFood breakfastFood)
        {
            _context.BreakfastFoods.Add(breakfastFood);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = breakfastFood.Id }, breakfastFood);
        }

        // PUT: api/BreakfastFoods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BreakfastFood breakfastFood)
        {
            if (id != breakfastFood.Id)
                return BadRequest("ID mismatch.");

            _context.Entry(breakfastFood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.BreakfastFoods.Any(e => e.Id == id))
                    return NotFound($"BreakfastFood with ID {id} was not found.");
                throw;
            }

            return NoContent();
        }

        // DELETE: api/BreakfastFoods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var food = await _context.BreakfastFoods.FindAsync(id);
            if (food == null)
                return NotFound($"BreakfastFood with ID {id} was not found.");

            _context.BreakfastFoods.Remove(food);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

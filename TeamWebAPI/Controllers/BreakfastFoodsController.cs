using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamWebAPI.Data;
using TeamWebAPI.Models;

namespace TeamWebAPI.Controllers
{
    /// <summary>
    /// Manages breakfast food records including name, category, calorie count, and preparation time.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BreakfastFoodsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BreakfastFoodsController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a breakfast food by ID, or returns the first 5 records if ID is null or zero.
        /// </summary>
        /// <param name="id">The breakfast food ID. Pass null or 0 to get the first 5 records.</param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get([FromQuery] int? id)
        {
            if (id == null || id == 0)
                return Ok(await _context.BreakfastFoods.Take(5).ToListAsync());

            var food = await _context.BreakfastFoods.FindAsync(id);
            if (food == null)
                return NotFound(new { message = $"Breakfast food with ID {id} not found." });

            return Ok(food);
        }

        /// <summary>
        /// Creates a new breakfast food record.
        /// </summary>
        /// <param name="food">The breakfast food to create.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BreakfastFood>> Create(BreakfastFood food)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.BreakfastFoods.Add(food);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = food.Id }, food);
        }

        /// <summary>
        /// Updates an existing breakfast food record.
        /// </summary>
        /// <param name="id">The ID of the breakfast food to update.</param>
        /// <param name="food">The updated breakfast food data.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, BreakfastFood food)
        {
            if (id != food.Id)
                return BadRequest(new { message = "Route ID does not match body ID." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.BreakfastFoods.Any(e => e.Id == id))
                    return NotFound(new { message = $"Breakfast food with ID {id} not found." });
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a breakfast food record by ID.
        /// </summary>
        /// <param name="id">The ID of the breakfast food to delete.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var food = await _context.BreakfastFoods.FindAsync(id);
            if (food == null)
                return NotFound(new { message = $"Breakfast food with ID {id} not found." });

            _context.BreakfastFoods.Remove(food);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

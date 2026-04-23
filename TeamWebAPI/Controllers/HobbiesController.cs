using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamWebAPI.Data;
using TeamWebAPI.Models;

namespace TeamWebAPI.Controllers
{
    /// <summary>
    /// Manages hobby records including name, category, skill level, and years active.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class HobbiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HobbiesController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a hobby by ID, or returns the first 5 records if ID is null or zero.
        /// </summary>
        /// <param name="id">The hobby ID. Pass null or 0 to get the first 5 records.</param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get([FromQuery] int? id)
        {
            if (id == null || id == 0)
                return Ok(await _context.Hobbies.Take(5).ToListAsync());

            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby == null)
                return NotFound(new { message = $"Hobby with ID {id} not found." });

            return Ok(hobby);
        }

        /// <summary>
        /// Creates a new hobby record.
        /// </summary>
        /// <param name="hobby">The hobby to create.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Hobby>> Create(Hobby hobby)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Hobbies.Add(hobby);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = hobby.Id }, hobby);
        }

        /// <summary>
        /// Updates an existing hobby record.
        /// </summary>
        /// <param name="id">The ID of the hobby to update.</param>
        /// <param name="hobby">The updated hobby data.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, Hobby hobby)
        {
            if (id != hobby.Id)
                return BadRequest(new { message = "Route ID does not match body ID." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(hobby).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Hobbies.Any(e => e.Id == id))
                    return NotFound(new { message = $"Hobby with ID {id} not found." });
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a hobby record by ID.
        /// </summary>
        /// <param name="id">The ID of the hobby to delete.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby == null)
                return NotFound(new { message = $"Hobby with ID {id} not found." });

            _context.Hobbies.Remove(hobby);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

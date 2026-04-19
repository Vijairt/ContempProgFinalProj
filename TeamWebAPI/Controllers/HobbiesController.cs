using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamWebAPI.Data;
using TeamWebAPI.Models;

namespace TeamWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HobbiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HobbiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Hobbies
        // GET: api/Hobbies/5
        // If id is null or 0, returns the first 5 records
        [HttpGet("{id?}")]
        public async Task<ActionResult<IEnumerable<Hobby>>> Get(int? id)
        {
            if (id == null || id == 0)
            {
                var first5 = await _context.Hobbies.Take(5).ToListAsync();
                return Ok(first5);
            }

            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby == null)
                return NotFound($"Hobby with ID {id} was not found.");

            return Ok(new List<Hobby> { hobby });
        }

        // POST: api/Hobbies
        [HttpPost]
        public async Task<ActionResult<Hobby>> Create(Hobby hobby)
        {
            _context.Hobbies.Add(hobby);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = hobby.Id }, hobby);
        }

        // PUT: api/Hobbies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Hobby hobby)
        {
            if (id != hobby.Id)
                return BadRequest("ID mismatch.");

            _context.Entry(hobby).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Hobbies.Any(e => e.Id == id))
                    return NotFound($"Hobby with ID {id} was not found.");
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Hobbies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby == null)
                return NotFound($"Hobby with ID {id} was not found.");

            _context.Hobbies.Remove(hobby);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

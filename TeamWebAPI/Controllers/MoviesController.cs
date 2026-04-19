using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamWebAPI.Data;
using TeamWebAPI.Models;

namespace TeamWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        // GET: api/Movies/5
        // If id is null or 0, returns the first 5 records
        [HttpGet("{id?}")]
        public async Task<ActionResult<IEnumerable<Movie>>> Get(int? id)
        {
            if (id == null || id == 0)
            {
                var first5 = await _context.Movies.Take(5).ToListAsync();
                return Ok(first5);
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                return NotFound($"Movie with ID {id} was not found.");

            return Ok(new List<Movie> { movie });
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<Movie>> Create(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Movie movie)
        {
            if (id != movie.Id)
                return BadRequest("ID mismatch.");

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Movies.Any(e => e.Id == id))
                    return NotFound($"Movie with ID {id} was not found.");
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                return NotFound($"Movie with ID {id} was not found.");

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

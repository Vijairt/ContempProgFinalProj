using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamWebAPI.Data;
using TeamWebAPI.Models;

namespace TeamWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteMoviesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FavoriteMoviesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/FavoriteMovies?id=0  (null or 0 returns first 5)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteMovie>>> Get([FromQuery] int? id)
        {
            if (id == null || id == 0)
                return Ok(await _context.FavoriteMovies.Take(5).ToListAsync());

            var movie = await _context.FavoriteMovies.FindAsync(id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        // POST: api/FavoriteMovies
        [HttpPost]
        public async Task<ActionResult<FavoriteMovie>> Create(FavoriteMovie movie)
        {
            _context.FavoriteMovies.Add(movie);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
        }

        // PUT: api/FavoriteMovies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FavoriteMovie movie)
        {
            if (id != movie.Id)
                return BadRequest();

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.FavoriteMovies.Any(e => e.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/FavoriteMovies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _context.FavoriteMovies.FindAsync(id);
            if (movie == null)
                return NotFound();

            _context.FavoriteMovies.Remove(movie);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

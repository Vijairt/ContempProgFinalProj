using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamWebAPI.Data;
using TeamWebAPI.Models;

namespace TeamWebAPI.Controllers
{
    /// <summary>
    /// Manages favorite movie records including title, genre, release year, director, and rating.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class FavoriteMoviesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FavoriteMoviesController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a favorite movie by ID, or returns the first 5 records if ID is null or zero.
        /// </summary>
        /// <param name="id">The movie ID. Pass null or 0 to get the first 5 records.</param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get([FromQuery] int? id)
        {
            if (id == null || id == 0)
                return Ok(await _context.FavoriteMovies.Take(5).ToListAsync());

            var movie = await _context.FavoriteMovies.FindAsync(id);
            if (movie == null)
                return NotFound(new { message = $"Movie with ID {id} not found." });

            return Ok(movie);
        }

        /// <summary>
        /// Creates a new favorite movie record.
        /// </summary>
        /// <param name="movie">The movie to create.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FavoriteMovie>> Create(FavoriteMovie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.FavoriteMovies.Add(movie);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
        }

        /// <summary>
        /// Updates an existing favorite movie record.
        /// </summary>
        /// <param name="id">The ID of the movie to update.</param>
        /// <param name="movie">The updated movie data.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, FavoriteMovie movie)
        {
            if (id != movie.Id)
                return BadRequest(new { message = "Route ID does not match body ID." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.FavoriteMovies.Any(e => e.Id == id))
                    return NotFound(new { message = $"Movie with ID {id} not found." });
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a favorite movie record by ID.
        /// </summary>
        /// <param name="id">The ID of the movie to delete.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _context.FavoriteMovies.FindAsync(id);
            if (movie == null)
                return NotFound(new { message = $"Movie with ID {id} not found." });

            _context.FavoriteMovies.Remove(movie);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

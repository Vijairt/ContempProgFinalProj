using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentWebAPI.Data;
using StudentWebAPI.Models;

namespace StudentWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly AppDbContext _context;

    public MoviesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Movies?id=0  -> returns first 5
    // GET: api/Movies?id=4  -> returns Movie with Id 4
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> Get([FromQuery] int? id)
    {
        if (id == null || id == 0)
            return await _context.Movies.Take(5).ToListAsync();

        var movie = await _context.Movies.FindAsync(id);
        if (movie == null) return NotFound();
        return Ok(new[] { movie });
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
        if (id != movie.Id) return BadRequest();
        _context.Entry(movie).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Movies.Any(e => e.Id == id)) return NotFound();
            throw;
        }
        return NoContent();
    }

    // DELETE: api/Movies/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null) return NotFound();
        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

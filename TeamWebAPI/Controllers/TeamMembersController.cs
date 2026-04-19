using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamWebAPI.Data;
using TeamWebAPI.Models;

namespace TeamWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamMembersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeamMembersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TeamMembers
        // GET: api/TeamMembers/5
        // If id is null or 0, returns the first 5 records
        [HttpGet("{id?}")]
        public async Task<ActionResult<IEnumerable<TeamMember>>> Get(int? id)
        {
            if (id == null || id == 0)
            {
                var first5 = await _context.TeamMembers.Take(5).ToListAsync();
                return Ok(first5);
            }

            var member = await _context.TeamMembers.FindAsync(id);
            if (member == null)
                return NotFound($"TeamMember with ID {id} was not found.");

            return Ok(new List<TeamMember> { member });
        }

        // POST: api/TeamMembers
        [HttpPost]
        public async Task<ActionResult<TeamMember>> Create(TeamMember teamMember)
        {
            _context.TeamMembers.Add(teamMember);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = teamMember.Id }, teamMember);
        }

        // PUT: api/TeamMembers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TeamMember teamMember)
        {
            if (id != teamMember.Id)
                return BadRequest("ID mismatch.");

            _context.Entry(teamMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TeamMembers.Any(e => e.Id == id))
                    return NotFound($"TeamMember with ID {id} was not found.");
                throw;
            }

            return NoContent();
        }

        // DELETE: api/TeamMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var member = await _context.TeamMembers.FindAsync(id);
            if (member == null)
                return NotFound($"TeamMember with ID {id} was not found.");

            _context.TeamMembers.Remove(member);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

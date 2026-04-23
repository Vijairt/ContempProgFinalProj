using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamWebAPI.Data;
using TeamWebAPI.Models;

namespace TeamWebAPI.Controllers
{
    /// <summary>
    /// Manages team member records including name, birthdate, college program, and year in program.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TeamMembersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeamMembersController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a team member by ID, or returns the first 5 records if ID is null or zero.
        /// </summary>
        /// <param name="id">The team member ID. Pass null or 0 to get the first 5 records.</param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get([FromQuery] int? id)
        {
            if (id == null || id == 0)
                return Ok(await _context.TeamMembers.Take(5).ToListAsync());

            var member = await _context.TeamMembers.FindAsync(id);
            if (member == null)
                return NotFound(new { message = $"Team member with ID {id} not found." });

            return Ok(member);
        }

        /// <summary>
        /// Creates a new team member record.
        /// </summary>
        /// <param name="member">The team member to create.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TeamMember>> Create(TeamMember member)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.TeamMembers.Add(member);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = member.Id }, member);
        }

        /// <summary>
        /// Updates an existing team member record.
        /// </summary>
        /// <param name="id">The ID of the team member to update.</param>
        /// <param name="member">The updated team member data.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, TeamMember member)
        {
            if (id != member.Id)
                return BadRequest(new { message = "Route ID does not match body ID." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TeamMembers.Any(e => e.Id == id))
                    return NotFound(new { message = $"Team member with ID {id} not found." });
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a team member record by ID.
        /// </summary>
        /// <param name="id">The ID of the team member to delete.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var member = await _context.TeamMembers.FindAsync(id);
            if (member == null)
                return NotFound(new { message = $"Team member with ID {id} not found." });

            _context.TeamMembers.Remove(member);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

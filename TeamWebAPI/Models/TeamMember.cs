using System.ComponentModel.DataAnnotations;

namespace TeamWebAPI.Models
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        [MaxLength(100)]
        public string CollegeProgram { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string YearInProgram { get; set; } = string.Empty; // Freshman, Sophomore, Junior, Senior

        [MaxLength(200)]
        public string? Email { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TeamWebAPI.Models
{
    public class TeamMember
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        [StringLength(100)]
        public string CollegeProgram { get; set; } = string.Empty;

        [Required]
        [RegularExpression("Freshman|Sophomore|Junior|Senior",
            ErrorMessage = "YearInProgram must be Freshman, Sophomore, Junior, or Senior.")]
        public string YearInProgram { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;
    }
}

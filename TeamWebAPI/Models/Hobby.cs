using System.ComponentModel.DataAnnotations;

namespace TeamWebAPI.Models
{
    public class Hobby
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Range(0, 100)]
        public int YearsActive { get; set; }

        [Required]
        [RegularExpression("Beginner|Intermediate|Advanced",
            ErrorMessage = "SkillLevel must be Beginner, Intermediate, or Advanced.")]
        public string SkillLevel { get; set; } = string.Empty;
    }
}

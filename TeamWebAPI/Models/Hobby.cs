using System.ComponentModel.DataAnnotations;

namespace TeamWebAPI.Models
{
    public class Hobby
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; } = string.Empty; // e.g., Outdoor, Indoor, Creative, Sports

        [Required]
        [MaxLength(20)]
        public string DifficultyLevel { get; set; } = string.Empty; // Easy, Medium, Hard

        public bool IsOutdoor { get; set; }
    }
}

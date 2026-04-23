using System.ComponentModel.DataAnnotations;

namespace TeamWebAPI.Models
{
    public class BreakfastFood
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        [Range(0, 10000)]
        public int CalorieCount { get; set; }

        public bool IsHealthy { get; set; }

        [Required]
        [StringLength(50)]
        public string PreparationTime { get; set; } = string.Empty;
    }
}

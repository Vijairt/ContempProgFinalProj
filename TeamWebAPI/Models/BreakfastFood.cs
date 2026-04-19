using System.ComponentModel.DataAnnotations;

namespace TeamWebAPI.Models
{
    public class BreakfastFood
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public int Calories { get; set; }

        public bool IsHealthy { get; set; }

        public int PreparationTimeMinutes { get; set; }

        [Required]
        [MaxLength(50)]
        public string Cuisine { get; set; } = string.Empty; // e.g., American, Mexican, Asian, European
    }
}

using System.ComponentModel.DataAnnotations;

namespace TeamWebAPI.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Genre { get; set; } = string.Empty;

        public int ReleaseYear { get; set; }

        [Range(0.0, 10.0)]
        public double Rating { get; set; }

        [MaxLength(100)]
        public string? Director { get; set; }
    }
}

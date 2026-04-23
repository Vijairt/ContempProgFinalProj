using System.ComponentModel.DataAnnotations;

namespace TeamWebAPI.Models
{
    public class FavoriteMovie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Genre { get; set; } = string.Empty;

        [Range(1888, 2100)]
        public int ReleaseYear { get; set; }

        [Required]
        [StringLength(100)]
        public string Director { get; set; } = string.Empty;

        [Range(1.0, 10.0)]
        public double Rating { get; set; }
    }
}

namespace TeamWebAPI.Models
{
    public class FavoriteMovie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string Director { get; set; } = string.Empty;
        public double Rating { get; set; } // 1.0 - 10.0
    }
}

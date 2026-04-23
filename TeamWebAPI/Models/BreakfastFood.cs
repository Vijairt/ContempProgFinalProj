namespace TeamWebAPI.Models
{
    public class BreakfastFood
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; // e.g. Cereal, Eggs, Pastry
        public int CalorieCount { get; set; }
        public bool IsHealthy { get; set; }
        public string PreparationTime { get; set; } = string.Empty; // e.g. "5 minutes"
    }
}

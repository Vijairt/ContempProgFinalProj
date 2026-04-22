namespace StudentWebAPI.Models;

public class BreakfastFood
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Cuisine { get; set; } = string.Empty;  // e.g. American, Mexican, Asian
    public int CaloriesPerServing { get; set; }
    public bool IsSweet { get; set; }
    public string PreparationTime { get; set; } = string.Empty; // e.g. "5 minutes", "20 minutes"
}

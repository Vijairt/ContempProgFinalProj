namespace StudentWebAPI.Models;

public class Hobby
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;  // e.g. Outdoor, Indoor, Creative
    public string Description { get; set; } = string.Empty;
    public int AverageHoursPerWeek { get; set; }
    public bool RequiresEquipment { get; set; }
}

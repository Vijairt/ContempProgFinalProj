using Microsoft.EntityFrameworkCore;
using StudentWebAPI.Models;

namespace StudentWebAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Hobby> Hobbies => Set<Hobby>();
    public DbSet<BreakfastFood> BreakfastFoods => Set<BreakfastFood>();
    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, FullName = "Rohit Vijay", Birthdate = new DateTime(2002, 5, 14), CollegeProgram = "Computer Science", YearInProgram = "Junior", Email = "rohit.vijay@college.edu" },
            new Student { Id = 2, FullName = "Alex Johnson", Birthdate = new DateTime(2001, 8, 22), CollegeProgram = "Software Engineering", YearInProgram = "Senior", Email = "alex.johnson@college.edu" },
            new Student { Id = 3, FullName = "Maria Garcia", Birthdate = new DateTime(2003, 3, 10), CollegeProgram = "Data Science", YearInProgram = "Sophomore", Email = "maria.garcia@college.edu" },
            new Student { Id = 4, FullName = "Liam Patel", Birthdate = new DateTime(2004, 11, 1), CollegeProgram = "Cybersecurity", YearInProgram = "Freshman", Email = "liam.patel@college.edu" },
            new Student { Id = 5, FullName = "Sara Kim", Birthdate = new DateTime(2000, 7, 30), CollegeProgram = "Computer Science", YearInProgram = "Senior", Email = "sara.kim@college.edu" }
        );

        modelBuilder.Entity<Hobby>().HasData(
            new Hobby { Id = 1, Name = "Rock Climbing", Category = "Outdoor", Description = "Scaling natural or artificial rock walls.", AverageHoursPerWeek = 5, RequiresEquipment = true },
            new Hobby { Id = 2, Name = "Painting", Category = "Creative", Description = "Expressing art using paint and canvas.", AverageHoursPerWeek = 4, RequiresEquipment = true },
            new Hobby { Id = 3, Name = "Reading", Category = "Indoor", Description = "Enjoying books of various genres.", AverageHoursPerWeek = 7, RequiresEquipment = false },
            new Hobby { Id = 4, Name = "Cycling", Category = "Outdoor", Description = "Riding bicycles for fitness or leisure.", AverageHoursPerWeek = 6, RequiresEquipment = true },
            new Hobby { Id = 5, Name = "Chess", Category = "Indoor", Description = "Strategic board game for two players.", AverageHoursPerWeek = 3, RequiresEquipment = true }
        );

        modelBuilder.Entity<BreakfastFood>().HasData(
            new BreakfastFood { Id = 1, Name = "Pancakes", Cuisine = "American", CaloriesPerServing = 350, IsSweet = true, PreparationTime = "20 minutes" },
            new BreakfastFood { Id = 2, Name = "Avocado Toast", Cuisine = "Modern", CaloriesPerServing = 250, IsSweet = false, PreparationTime = "10 minutes" },
            new BreakfastFood { Id = 3, Name = "Eggs Benedict", Cuisine = "American", CaloriesPerServing = 450, IsSweet = false, PreparationTime = "25 minutes" },
            new BreakfastFood { Id = 4, Name = "Acai Bowl", Cuisine = "Brazilian", CaloriesPerServing = 300, IsSweet = true, PreparationTime = "5 minutes" },
            new BreakfastFood { Id = 5, Name = "Croissant", Cuisine = "French", CaloriesPerServing = 270, IsSweet = false, PreparationTime = "2 minutes" }
        );

        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", ReleaseYear = 2010, Director = "Christopher Nolan", Rating = 8.8 },
            new Movie { Id = 2, Title = "The Dark Knight", Genre = "Action", ReleaseYear = 2008, Director = "Christopher Nolan", Rating = 9.0 },
            new Movie { Id = 3, Title = "Interstellar", Genre = "Sci-Fi", ReleaseYear = 2014, Director = "Christopher Nolan", Rating = 8.6 },
            new Movie { Id = 4, Title = "Parasite", Genre = "Thriller", ReleaseYear = 2019, Director = "Bong Joon-ho", Rating = 8.5 },
            new Movie { Id = 5, Title = "The Shawshank Redemption", Genre = "Drama", ReleaseYear = 1994, Director = "Frank Darabont", Rating = 9.3 }
        );
    }
}

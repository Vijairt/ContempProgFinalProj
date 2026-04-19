using Microsoft.EntityFrameworkCore;
using TeamWebAPI.Models;

namespace TeamWebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<BreakfastFood> BreakfastFoods { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed TeamMembers
            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember { Id = 1, FullName = "Alice Johnson", Birthdate = new DateTime(2002, 3, 15), CollegeProgram = "Computer Science", YearInProgram = "Junior", Email = "alice@example.com" },
                new TeamMember { Id = 2, FullName = "Bob Smith", Birthdate = new DateTime(2001, 7, 22), CollegeProgram = "Software Engineering", YearInProgram = "Senior", Email = "bob@example.com" },
                new TeamMember { Id = 3, FullName = "Carol Davis", Birthdate = new DateTime(2003, 11, 5), CollegeProgram = "Information Technology", YearInProgram = "Sophomore", Email = "carol@example.com" },
                new TeamMember { Id = 4, FullName = "David Lee", Birthdate = new DateTime(2004, 1, 30), CollegeProgram = "Cybersecurity", YearInProgram = "Freshman", Email = "david@example.com" },
                new TeamMember { Id = 5, FullName = "Emma Wilson", Birthdate = new DateTime(2000, 9, 18), CollegeProgram = "Data Science", YearInProgram = "Senior", Email = "emma@example.com" }
            );

            // Seed Hobbies
            modelBuilder.Entity<Hobby>().HasData(
                new Hobby { Id = 1, Name = "Hiking", Description = "Trekking through natural trails", Category = "Outdoor", DifficultyLevel = "Medium", IsOutdoor = true },
                new Hobby { Id = 2, Name = "Painting", Description = "Creating art with various paint media", Category = "Creative", DifficultyLevel = "Easy", IsOutdoor = false },
                new Hobby { Id = 3, Name = "Rock Climbing", Description = "Scaling natural and artificial rock faces", Category = "Sports", DifficultyLevel = "Hard", IsOutdoor = true },
                new Hobby { Id = 4, Name = "Reading", Description = "Exploring books across all genres", Category = "Indoor", DifficultyLevel = "Easy", IsOutdoor = false },
                new Hobby { Id = 5, Name = "Photography", Description = "Capturing moments through a lens", Category = "Creative", DifficultyLevel = "Medium", IsOutdoor = false }
            );

            // Seed BreakfastFoods
            modelBuilder.Entity<BreakfastFood>().HasData(
                new BreakfastFood { Id = 1, Name = "Avocado Toast", Calories = 250, IsHealthy = true, PreparationTimeMinutes = 10, Cuisine = "American" },
                new BreakfastFood { Id = 2, Name = "Pancakes", Calories = 450, IsHealthy = false, PreparationTimeMinutes = 20, Cuisine = "American" },
                new BreakfastFood { Id = 3, Name = "Overnight Oats", Calories = 320, IsHealthy = true, PreparationTimeMinutes = 5, Cuisine = "European" },
                new BreakfastFood { Id = 4, Name = "Breakfast Burrito", Calories = 550, IsHealthy = false, PreparationTimeMinutes = 15, Cuisine = "Mexican" },
                new BreakfastFood { Id = 5, Name = "Acai Bowl", Calories = 380, IsHealthy = true, PreparationTimeMinutes = 8, Cuisine = "Brazilian" }
            );

            // Seed Movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", ReleaseYear = 2010, Rating = 8.8, Director = "Christopher Nolan" },
                new Movie { Id = 2, Title = "The Dark Knight", Genre = "Action", ReleaseYear = 2008, Rating = 9.0, Director = "Christopher Nolan" },
                new Movie { Id = 3, Title = "Interstellar", Genre = "Sci-Fi", ReleaseYear = 2014, Rating = 8.6, Director = "Christopher Nolan" },
                new Movie { Id = 4, Title = "Parasite", Genre = "Thriller", ReleaseYear = 2019, Rating = 8.5, Director = "Bong Joon-ho" },
                new Movie { Id = 5, Title = "The Shawshank Redemption", Genre = "Drama", ReleaseYear = 1994, Rating = 9.3, Director = "Frank Darabont" }
            );
        }
    }
}

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
        public DbSet<FavoriteMovie> FavoriteMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember { Id = 1, FullName = "Alex Johnson", Birthdate = new DateTime(2002, 3, 14), CollegeProgram = "Computer Science", YearInProgram = "Junior", Email = "alex.johnson@school.edu" },
                new TeamMember { Id = 2, FullName = "Maria Garcia", Birthdate = new DateTime(2003, 7, 22), CollegeProgram = "Software Engineering", YearInProgram = "Sophomore", Email = "maria.garcia@school.edu" },
                new TeamMember { Id = 3, FullName = "James Lee", Birthdate = new DateTime(2001, 11, 5), CollegeProgram = "Information Technology", YearInProgram = "Senior", Email = "james.lee@school.edu" },
                new TeamMember { Id = 4, FullName = "Priya Patel", Birthdate = new DateTime(2004, 1, 30), CollegeProgram = "Computer Science", YearInProgram = "Freshman", Email = "priya.patel@school.edu" },
                new TeamMember { Id = 5, FullName = "Tyler Brooks", Birthdate = new DateTime(2002, 9, 18), CollegeProgram = "Cybersecurity", YearInProgram = "Junior", Email = "tyler.brooks@school.edu" },
                new TeamMember { Id = 6, FullName = "Samantha Wu", Birthdate = new DateTime(2003, 4, 12), CollegeProgram = "Data Science", YearInProgram = "Sophomore", Email = "samantha.wu@school.edu" }
            );

            modelBuilder.Entity<Hobby>().HasData(
                new Hobby { Id = 1, Name = "Photography", Category = "Creative", Description = "Capturing moments with a DSLR camera", YearsActive = 4, SkillLevel = "Intermediate" },
                new Hobby { Id = 2, Name = "Rock Climbing", Category = "Outdoor", Description = "Indoor and outdoor bouldering and sport climbing", YearsActive = 2, SkillLevel = "Beginner" },
                new Hobby { Id = 3, Name = "Chess", Category = "Indoor", Description = "Competitive chess player, online and in-person", YearsActive = 10, SkillLevel = "Advanced" },
                new Hobby { Id = 4, Name = "Painting", Category = "Creative", Description = "Acrylic and watercolor painting on canvas", YearsActive = 6, SkillLevel = "Intermediate" },
                new Hobby { Id = 5, Name = "Hiking", Category = "Outdoor", Description = "Weekend trail hiking in national parks", YearsActive = 3, SkillLevel = "Intermediate" },
                new Hobby { Id = 6, Name = "Gaming", Category = "Indoor", Description = "PC and console gaming, mostly RPGs and strategy", YearsActive = 8, SkillLevel = "Advanced" }
            );

            modelBuilder.Entity<BreakfastFood>().HasData(
                new BreakfastFood { Id = 1, Name = "Avocado Toast", Category = "Toast", CalorieCount = 320, IsHealthy = true, PreparationTime = "10 minutes" },
                new BreakfastFood { Id = 2, Name = "Pancakes", Category = "Pastry", CalorieCount = 520, IsHealthy = false, PreparationTime = "20 minutes" },
                new BreakfastFood { Id = 3, Name = "Greek Yogurt with Granola", Category = "Yogurt", CalorieCount = 280, IsHealthy = true, PreparationTime = "2 minutes" },
                new BreakfastFood { Id = 4, Name = "Bacon and Eggs", Category = "Eggs", CalorieCount = 450, IsHealthy = false, PreparationTime = "15 minutes" },
                new BreakfastFood { Id = 5, Name = "Oatmeal with Berries", Category = "Cereal", CalorieCount = 210, IsHealthy = true, PreparationTime = "5 minutes" },
                new BreakfastFood { Id = 6, Name = "Breakfast Burrito", Category = "Wrap", CalorieCount = 580, IsHealthy = false, PreparationTime = "15 minutes" }
            );

            modelBuilder.Entity<FavoriteMovie>().HasData(
                new FavoriteMovie { Id = 1, Title = "Inception", Genre = "Sci-Fi", ReleaseYear = 2010, Director = "Christopher Nolan", Rating = 8.8 },
                new FavoriteMovie { Id = 2, Title = "The Dark Knight", Genre = "Action", ReleaseYear = 2008, Director = "Christopher Nolan", Rating = 9.0 },
                new FavoriteMovie { Id = 3, Title = "Interstellar", Genre = "Sci-Fi", ReleaseYear = 2014, Director = "Christopher Nolan", Rating = 8.6 },
                new FavoriteMovie { Id = 4, Title = "Parasite", Genre = "Thriller", ReleaseYear = 2019, Director = "Bong Joon-ho", Rating = 8.5 },
                new FavoriteMovie { Id = 5, Title = "The Matrix", Genre = "Sci-Fi", ReleaseYear = 1999, Director = "The Wachowskis", Rating = 8.7 },
                new FavoriteMovie { Id = 6, Title = "Spirited Away", Genre = "Animation", ReleaseYear = 2001, Director = "Hayao Miyazaki", Rating = 8.6 }
            );
        }
    }
}

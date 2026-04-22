using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreakfastFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Cuisine = table.Column<string>(type: "TEXT", nullable: false),
                    CaloriesPerServing = table.Column<int>(type: "INTEGER", nullable: false),
                    IsSweet = table.Column<bool>(type: "INTEGER", nullable: false),
                    PreparationTime = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakfastFoods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    AverageHoursPerWeek = table.Column<int>(type: "INTEGER", nullable: false),
                    RequiresEquipment = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseYear = table.Column<int>(type: "INTEGER", nullable: false),
                    Director = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CollegeProgram = table.Column<string>(type: "TEXT", nullable: false),
                    YearInProgram = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BreakfastFoods",
                columns: new[] { "Id", "CaloriesPerServing", "Cuisine", "IsSweet", "Name", "PreparationTime" },
                values: new object[,]
                {
                    { 1, 350, "American", true, "Pancakes", "20 minutes" },
                    { 2, 250, "Modern", false, "Avocado Toast", "10 minutes" },
                    { 3, 450, "American", false, "Eggs Benedict", "25 minutes" },
                    { 4, 300, "Brazilian", true, "Acai Bowl", "5 minutes" },
                    { 5, 270, "French", false, "Croissant", "2 minutes" }
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "Id", "AverageHoursPerWeek", "Category", "Description", "Name", "RequiresEquipment" },
                values: new object[,]
                {
                    { 1, 5, "Outdoor", "Scaling natural or artificial rock walls.", "Rock Climbing", true },
                    { 2, 4, "Creative", "Expressing art using paint and canvas.", "Painting", true },
                    { 3, 7, "Indoor", "Enjoying books of various genres.", "Reading", false },
                    { 4, 6, "Outdoor", "Riding bicycles for fitness or leisure.", "Cycling", true },
                    { 5, 3, "Indoor", "Strategic board game for two players.", "Chess", true }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "Genre", "Rating", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "Christopher Nolan", "Sci-Fi", 8.8000000000000007, 2010, "Inception" },
                    { 2, "Christopher Nolan", "Action", 9.0, 2008, "The Dark Knight" },
                    { 3, "Christopher Nolan", "Sci-Fi", 8.5999999999999996, 2014, "Interstellar" },
                    { 4, "Bong Joon-ho", "Thriller", 8.5, 2019, "Parasite" },
                    { 5, "Frank Darabont", "Drama", 9.3000000000000007, 1994, "The Shawshank Redemption" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Birthdate", "CollegeProgram", "Email", "FullName", "YearInProgram" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Science", "rohit.vijay@college.edu", "Rohit Vijay", "Junior" },
                    { 2, new DateTime(2001, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Engineering", "alex.johnson@college.edu", "Alex Johnson", "Senior" },
                    { 3, new DateTime(2003, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Data Science", "maria.garcia@college.edu", "Maria Garcia", "Sophomore" },
                    { 4, new DateTime(2004, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cybersecurity", "liam.patel@college.edu", "Liam Patel", "Freshman" },
                    { 5, new DateTime(2000, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Science", "sara.kim@college.edu", "Sara Kim", "Senior" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreakfastFoods");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}

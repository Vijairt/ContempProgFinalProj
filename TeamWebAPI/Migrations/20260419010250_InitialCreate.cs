using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeamWebAPI.Migrations
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    IsHealthy = table.Column<bool>(type: "bit", nullable: false),
                    PreparationTimeMinutes = table.Column<int>(type: "int", nullable: false),
                    Cuisine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakfastFoods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsOutdoor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CollegeProgram = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YearInProgram = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BreakfastFoods",
                columns: new[] { "Id", "Calories", "Cuisine", "IsHealthy", "Name", "PreparationTimeMinutes" },
                values: new object[,]
                {
                    { 1, 250, "American", true, "Avocado Toast", 10 },
                    { 2, 450, "American", false, "Pancakes", 20 },
                    { 3, 320, "European", true, "Overnight Oats", 5 },
                    { 4, 550, "Mexican", false, "Breakfast Burrito", 15 },
                    { 5, 380, "Brazilian", true, "Acai Bowl", 8 }
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "Id", "Category", "Description", "DifficultyLevel", "IsOutdoor", "Name" },
                values: new object[,]
                {
                    { 1, "Outdoor", "Trekking through natural trails", "Medium", true, "Hiking" },
                    { 2, "Creative", "Creating art with various paint media", "Easy", false, "Painting" },
                    { 3, "Sports", "Scaling natural and artificial rock faces", "Hard", true, "Rock Climbing" },
                    { 4, "Indoor", "Exploring books across all genres", "Easy", false, "Reading" },
                    { 5, "Creative", "Capturing moments through a lens", "Medium", false, "Photography" }
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
                table: "TeamMembers",
                columns: new[] { "Id", "Birthdate", "CollegeProgram", "Email", "FullName", "YearInProgram" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Science", "alice@example.com", "Alice Johnson", "Junior" },
                    { 2, new DateTime(2001, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Engineering", "bob@example.com", "Bob Smith", "Senior" },
                    { 3, new DateTime(2003, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Information Technology", "carol@example.com", "Carol Davis", "Sophomore" },
                    { 4, new DateTime(2004, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cybersecurity", "david@example.com", "David Lee", "Freshman" },
                    { 5, new DateTime(2000, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Data Science", "emma@example.com", "Emma Wilson", "Senior" }
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
                name: "TeamMembers");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeamWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAndAnnotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "TeamMembers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TeamMembers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CollegeProgram",
                table: "TeamMembers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hobbies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Hobbies",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Hobbies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "FavoriteMovies",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "FavoriteMovies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Director",
                table: "FavoriteMovies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PreparationTime",
                table: "BreakfastFoods",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BreakfastFoods",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "BreakfastFoods",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "BreakfastFoods",
                columns: new[] { "Id", "CalorieCount", "Category", "IsHealthy", "Name", "PreparationTime" },
                values: new object[,]
                {
                    { 1, 320, "Toast", true, "Avocado Toast", "10 minutes" },
                    { 2, 520, "Pastry", false, "Pancakes", "20 minutes" },
                    { 3, 280, "Yogurt", true, "Greek Yogurt with Granola", "2 minutes" },
                    { 4, 450, "Eggs", false, "Bacon and Eggs", "15 minutes" },
                    { 5, 210, "Cereal", true, "Oatmeal with Berries", "5 minutes" },
                    { 6, 580, "Wrap", false, "Breakfast Burrito", "15 minutes" }
                });

            migrationBuilder.InsertData(
                table: "FavoriteMovies",
                columns: new[] { "Id", "Director", "Genre", "Rating", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "Christopher Nolan", "Sci-Fi", 8.8000000000000007, 2010, "Inception" },
                    { 2, "Christopher Nolan", "Action", 9.0, 2008, "The Dark Knight" },
                    { 3, "Christopher Nolan", "Sci-Fi", 8.5999999999999996, 2014, "Interstellar" },
                    { 4, "Bong Joon-ho", "Thriller", 8.5, 2019, "Parasite" },
                    { 5, "The Wachowskis", "Sci-Fi", 8.6999999999999993, 1999, "The Matrix" },
                    { 6, "Hayao Miyazaki", "Animation", 8.5999999999999996, 2001, "Spirited Away" }
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "Id", "Category", "Description", "Name", "SkillLevel", "YearsActive" },
                values: new object[,]
                {
                    { 1, "Creative", "Capturing moments with a DSLR camera", "Photography", "Intermediate", 4 },
                    { 2, "Outdoor", "Indoor and outdoor bouldering and sport climbing", "Rock Climbing", "Beginner", 2 },
                    { 3, "Indoor", "Competitive chess player, online and in-person", "Chess", "Advanced", 10 },
                    { 4, "Creative", "Acrylic and watercolor painting on canvas", "Painting", "Intermediate", 6 },
                    { 5, "Outdoor", "Weekend trail hiking in national parks", "Hiking", "Intermediate", 3 },
                    { 6, "Indoor", "PC and console gaming, mostly RPGs and strategy", "Gaming", "Advanced", 8 }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "Birthdate", "CollegeProgram", "Email", "FullName", "YearInProgram" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Science", "alex.johnson@school.edu", "Alex Johnson", "Junior" },
                    { 2, new DateTime(2003, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Engineering", "maria.garcia@school.edu", "Maria Garcia", "Sophomore" },
                    { 3, new DateTime(2001, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Information Technology", "james.lee@school.edu", "James Lee", "Senior" },
                    { 4, new DateTime(2004, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Science", "priya.patel@school.edu", "Priya Patel", "Freshman" },
                    { 5, new DateTime(2002, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cybersecurity", "tyler.brooks@school.edu", "Tyler Brooks", "Junior" },
                    { 6, new DateTime(2003, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Data Science", "samantha.wu@school.edu", "Samantha Wu", "Sophomore" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BreakfastFoods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BreakfastFoods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BreakfastFoods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BreakfastFoods",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BreakfastFoods",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BreakfastFoods",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FavoriteMovies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FavoriteMovies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FavoriteMovies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FavoriteMovies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FavoriteMovies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FavoriteMovies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hobbies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hobbies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hobbies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hobbies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hobbies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hobbies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "CollegeProgram",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hobbies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Hobbies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Hobbies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "FavoriteMovies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "FavoriteMovies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Director",
                table: "FavoriteMovies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "PreparationTime",
                table: "BreakfastFoods",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BreakfastFoods",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "BreakfastFoods",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}

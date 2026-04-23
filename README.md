# Team Web API

An ASP.NET Core 8 Web API built with Entity Framework Core (Code First) and NSwag for API documentation.

## Tables / Controllers

| Controller | Table | Description |
|---|---|---|
| `TeamMembersController` | `TeamMembers` | Team member info including name, birthdate, program, and year |
| `HobbiesController` | `Hobbies` | Hobby entries with category, skill level, and years active |
| `BreakfastFoodsController` | `BreakfastFoods` | Breakfast food items with calorie count and prep time |
| `FavoriteMoviesController` | `FavoriteMovies` | Favorite movies with genre, director, year, and rating |

## CRUD Endpoints (per controller)

| Method | Route | Description |
|---|---|---|
| `GET` | `/api/{controller}?id=0` | Returns first 5 records if id is null or 0, otherwise returns single record |
| `POST` | `/api/{controller}` | Creates a new record |
| `PUT` | `/api/{controller}/{id}` | Updates an existing record |
| `DELETE` | `/api/{controller}/{id}` | Deletes a record |

## Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server or LocalDB

### Setup

1. Clone the repository
2. Update the connection string in `TeamWebAPI/appsettings.json` if needed
3. Run migrations:
   ```
   cd TeamWebAPI
   dotnet ef database update
   ```
4. Run the API:
   ```
   dotnet run
   ```
5. Open your browser to `https://localhost:{port}/swagger` to explore the API via NSwag UI

## Tech Stack
- ASP.NET Core 8
- Entity Framework Core 8 (Code First)
- SQL Server / LocalDB
- NSwag (OpenAPI / Swagger UI)

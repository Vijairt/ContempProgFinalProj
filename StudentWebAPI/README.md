# StudentWebAPI

ASP.NET Core Web API — IT3045C Final Project  
**.NET 9 | Entity Framework Core 9 (Code First) | SQLite | NSwag (OpenAPI/Swagger)**

---

## Project Structure (MVC Pattern)

```
StudentWebAPI/
│
├── Controllers/                  # API Controllers — one per table
│   ├── StudentsController.cs     # Team member info (required table)
│   ├── HobbiesController.cs      # Hobbies table
│   ├── BreakfastFoodsController.cs  # Breakfast Foods table
│   └── MoviesController.cs       # Movies table
│
├── Models/                       # Entity/Model classes (Code First schema)
│   ├── Student.cs
│   ├── Hobby.cs
│   ├── BreakfastFood.cs
│   └── Movie.cs
│
├── Data/                         # EF Core DbContext & seed data
│   └── AppDbContext.cs
│
├── Migrations/                   # EF Core generated migrations
│   ├── <timestamp>_InitialCreate.cs
│   ├── <timestamp>_InitialCreate.Designer.cs
│   └── AppDbContextModelSnapshot.cs
│
├── Properties/
│   └── launchSettings.json
│
├── appsettings.json              # Connection string & app config
├── appsettings.Development.json
└── Program.cs                    # App entry point — DI, EF, NSwag wired here
```

---

## Rubric Compliance Checklist

| Requirement | Detail |
|---|---|
| **.NET version** | `net9.0` — exceeds .NET 6 minimum |
| **EF Core Code First** | `AppDbContext` with `DbSet<T>` for each table; schema driven by models |
| **Migrations folder** | `Migrations/` folder created via `dotnet ef migrations add InitialCreate` |
| **EF Core Seed Data** | `OnModelCreating` uses `HasData()` to seed 5 rows per table |
| **Git / GitHub VCS** | Repo: https://github.com/Vijairt/ContempProgFinalProj (branch: master) |
| **NSwag OpenAPI** | `NSwag.AspNetCore` package; Swagger UI served at `/swagger` |
| **Students CRUD** | Full Create, Read (single/first-5), Update, Delete |
| **3 additional controllers** | Hobbies, BreakfastFoods, Movies — each with full CRUD |
| **MVC structure** | Controllers/, Models/, Data/, Migrations/ — standard ASP.NET MVC layout |

---

## Tables & Columns

### Students (required — team member info)
| Column | Type |
|---|---|
| Id (PK) | int |
| FullName | string |
| Birthdate | DateTime |
| CollegeProgram | string |
| YearInProgram | string (Freshman/Sophomore/Junior/Senior) |
| Email | string |

### Hobbies
| Column | Type |
|---|---|
| Id (PK) | int |
| Name | string |
| Category | string |
| Description | string |
| AverageHoursPerWeek | int |
| RequiresEquipment | bool |

### BreakfastFoods
| Column | Type |
|---|---|
| Id (PK) | int |
| Name | string |
| Cuisine | string |
| CaloriesPerServing | int |
| IsSweet | bool |
| PreparationTime | string |

### Movies
| Column | Type |
|---|---|
| Id (PK) | int |
| Title | string |
| Genre | string |
| ReleaseYear | int |
| Director | string |
| Rating | double |

---

## CRUD Operations — All 4 Controllers

| Operation | HTTP Method | Route | Behavior |
|---|---|---|---|
| **Read** | GET | `/api/{entity}?id=0` | Returns first **5** records |
| **Read** | GET | `/api/{entity}?id={n}` | Returns single record by id |
| **Create** | POST | `/api/{entity}` | Creates a new record |
| **Update** | PUT | `/api/{entity}/{id}` | Updates an existing record |
| **Delete** | DELETE | `/api/{entity}/{id}` | Deletes a record |

---

## Running the API

```powershell
cd StudentWebAPI
dotnet run
```

- The SQLite database (`studentapi.db`) is **created automatically** on first run.
- Seed data (5 rows per table) is inserted via EF Core `HasData()` + `Migrate()`.
- Open **`https://localhost:{port}/swagger`** to view and test all endpoints via NSwag Swagger UI.

---

## Running Migrations Manually

```powershell
cd StudentWebAPI
dotnet tool run dotnet-ef database update
```

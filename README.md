# Products API: Clean Architecture + CQRS (Huma Volve Task 3)

A Products REST API built with ASP.NET Core, following Clean Architecture and the CQRS pattern with MediatR.

## Swagger

![Swagger UI](ProductsAPIs.png)

## Tech Stack

- ASP.NET Core Web API
- Entity Framework Core + SQL Server
- MediatR (CQRS)
- Data Annotations validation

## Architecture

| Project | Responsibility |
|---|---|
| `Products.Domain` | Entities (`Product`) |
| `Products.Application` | Commands, Queries, Handlers, DTOs, repository interface |
| `Products.Infrastructure` | EF Core `AppDbContext`, repository implementation, migrations |
| `Products.API` | Controllers, request DTOs, `Program.cs` (composition root) |

Dependencies point inward: API → Application → Domain, and Infrastructure → Application.

## Endpoints

| Method | Route | Description |
|---|---|---|
| GET | `/api/products` | Get all products |
| GET | `/api/products/{id}` | Get a product by id (404 if not found) |
| POST | `/api/products` | Create a product (201) |
| PUT | `/api/products/{id}` | Update a product (204 / 404) |
| DELETE | `/api/products/{id}` | Delete a product (204 / 404) |

## Validation

- `Name`: required, 2 to 100 characters
- `Price`: between 0.01 and 1,000,000

## How to Run

1. Update the connection string in `Products.API/appsettings.json` if needed.
2. Apply the migration: `Update-Database` (Package Manager Console, default project `Products.Infrastructure`, startup project `Products.API`).
3. Run `Products.API` and open Swagger.

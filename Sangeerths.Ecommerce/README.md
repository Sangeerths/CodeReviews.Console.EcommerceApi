# Ecommerce.API

A RESTful Web API for managing an e-commerce catalog — built with **ASP.NET Core** and **Entity Framework Core**. It exposes endpoints for managing **Products**, **Categories**, and **Sales**, with pagination and soft-delete support baked in.

## 🚀 Overview

This project was built to demonstrate a practical e-commerce backend using a clean separation between:

- **API layer** – exposes RESTful endpoints
- **Service layer** – contains application/business logic
- **Data layer** – handles database access with Entity Framework Core
- **DTOs** – separates API contracts from database entities
- **Console UI** – provides an interactive client for managing the application
  
## Features

- CRUD operations for Products, Categories, and Sales
- Paginated list endpoints (`PageNumber`, `PageSize`)
- Soft delete (records are flagged `IsDeleted` / `DeletedAt` rather than removed)
- DTO-based request/response separation to keep the API contract independent of the data model
- EF Core for data access

## Tech Stack

- **.NET / ASP.NET Core Web API**
- **Entity Framework Core** (`EcommerceDbContext`)
- SQL database (via EF Core provider — see `appsettings.json` for connection string)

## 🏗️ Architecture

```text
                    ┌──────────────────────┐
                    │     ECommerce.UI     │
                    │  .NET Console Client │
                    └──────────┬───────────┘
                               │
                          HTTP / JSON
                               │
                               ▼
                    ┌──────────────────────┐
                    │    ASP.NET Core API  │
                    │      Controllers     │
                    └──────────┬───────────┘
                               │
                               ▼
                    ┌──────────────────────┐
                    │      Services        │
                    │ Business Logic Layer │
                    └──────────┬───────────┘
                               │
                               ▼
                    ┌──────────────────────┐
                    │    EF Core / DbContext│
                    │    Data Access Layer │
                    └──────────┬───────────┘
                               │
                               ▼
                    ┌──────────────────────┐
                    │      SQL Server      │
                    │     EcommerceDb      │
                    └──────────────────────┘
```


## 📁 Project Structure

```text
Ecommerce.API/
│
├── Ecommerce.API/
│   │
│   ├── Controllers/
│   │   ├── ProductController.cs
│   │   ├── CategoryController.cs
│   │   └── SaleController.cs
│   │
│   ├── Services/
│   │   ├── ProductService.cs
│   │   ├── CategoryService.cs
│   │   └── SaleService.cs
│   │
│   ├── DTO/
│   │   ├── Product/
│   │   ├── Category/
│   │   ├── Sale/
│   │   └── Pagination/
│   │
│   ├── Models/
│   │   ├── Product.cs
│   │   ├── Category.cs
│   │   ├── Sale.cs
│   │   └── SaleItem.cs
│   │
│   ├── Data/
│   │   └── EcommerceDbContext.cs
│   │
│   ├── Program.cs
│   ├── appsettings.json
│   └── Ecommerce.API.csproj
│
├── ECommerce.UI/
│   │
│   ├── Menu/
│   │   ├── MenuUI.cs
│   │   └── ConsoleHelper.cs
│   │
│   ├── Services/
│   │   ├── ProductApiService.cs
│   │   ├── CategoryApiService.cs
│   │   └── SaleApiService.cs
│   │
│   ├── DTO/
│   ├── Program.cs
│   ├── appsettings.json
│   └── ECommerce.UI.csproj
│
├── Ecommerce.API.postman_collection.json
├── Ecommerce.API.slnx
└── README.md
```

The solution file contains both the API and console client projects.


## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) 
- A SQL Server

### Setup

## 1. Clone the Repository

```bash
git clone https://github.com/Sangeerths/Ecommerce.API.git
cd Ecommerce.API
```


2. Configure your database connection string in `appsettings.json` (or `appsettings.Development.json`):
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "<your-connection-string>"
     }
   }
   ```

## 3. Apply EF Core Migrations

From the solution directory:

```bash
dotnet ef database update
```

If the EF CLI tool is not installed:

```bash
dotnet tool install --global dotnet-ef
```

## 4. Build the Solution

```bash
dotnet build
```

---

## 5. Run the API

```bash
dotnet run --project Ecommerce.API
```

The API is configured for HTTPS and the current Postman collection uses:

```text
https://localhost:7146
```

All list endpoints return a `PagedResponse<T>` containing the items plus pagination metadata (page number, page size, total records).

## Testing the API

A Postman collection (`Ecommerce.API.postman_collection.json`) covering all endpoints is included in the repo. Import it into Postman and set the `base_url` variable to match your running instance to get started quickly.


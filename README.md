# MyAmazingApp New one

A .NET console application that demonstrates a simple order management system using an in-memory repository pattern.

## Project Overview

MyAmazingApp manages customers, orders, and order items through a clean repository abstraction. It supports creating orders, adding items, updating order statuses, filtering by status, and removing orders — all backed by an in-memory store.

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download)

## Setup Instructions

1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd GH900-97940
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

## How to Run Locally

```bash
dotnet run --project MyAmazingConsole
```

The application will create sample orders, display them, update statuses, filter by status, retrieve a specific order by ID, and remove an order.

## How to Test

Run the xUnit test suite:

```bash
dotnet test
```

Tests are located in the `MyAmazingConsole.Tests` project and cover `OrderItem` construction, property validation, and total cost calculation.

## Project Structure

```
GH900-97940/
├── MyAmazingApp.slnx                  # Solution file
├── MyAmazingConsole/                  # Main console application
│   ├── Interfaces/
│   │   └── IOrderRepository.cs        # Repository interface
│   ├── Models/
│   │   ├── Customer.cs
│   │   ├── Order.cs
│   │   ├── OrderItem.cs
│   │   └── OrderStatus.cs
│   ├── Repositories/
│   │   └── InMemoryOrderRepository.cs # In-memory implementation
│   └── Program.cs                     # Application entry point
└── MyAmazingConsole.Tests/            # xUnit test project
    └── OrderItemTests.cs
```

## Useful Commands

| Command | Description |
|---|---|
| `dotnet restore` | Restore NuGet packages |
| `dotnet build` | Build the solution |
| `dotnet run --project MyAmazingConsole` | Run the console app |
| `dotnet test` | Run all tests |
| `dotnet test --logger "console;verbosity=detailed"` | Run tests with detailed output |

## Contributing Notes

- Follow existing code style and naming conventions.
- Add or update tests in `MyAmazingConsole.Tests` for any logic changes.
- Ensure `dotnet build` and `dotnet test` pass before submitting a pull request.

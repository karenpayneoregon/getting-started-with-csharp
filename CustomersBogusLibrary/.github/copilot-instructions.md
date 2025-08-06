# Copilot Instructions for CustomersBogusLibrary

## Project Overview
- **Purpose:** This is a .NET 9.0 class library for generating and modeling customer data, primarily using the [Bogus](https://github.com/bchavez/Bogus) library for realistic fake data.
- **Key Components:**
  - `Classes/BogusCustomer.cs`: Main entry for generating fake customers.
  - `Models/`: Contains core data models (`Customer`, `Person`, `Address`, `Gender`, `ConnectionStrings`).
  - `Interfaces/`: Defines contracts for models (`IPerson`, `IAddress`).

## Architecture & Patterns
- **Data Generation:**
  - Use `BogusCustomer.GenerateCustomers(int count = 10)` to create lists of `Customer` objects with seeded, repeatable fake data.
  - Gender-aware first names are enforced (see `BogusCustomer.cs` for custom logic).
- **Model Structure:**
  - `Customer` and `Person` are separate; `Person` includes an `Address`, while `Customer` does not by default.
  - All models are in `Models/` and implement interfaces from `Interfaces/` when appropriate.
- **Enums:**
  - `Gender` enum is used for gender-specific data generation and model typing.

## Developer Workflows
- **Build:**
  - Standard .NET build: `dotnet build` from the project root.
- **Test:**
  - No test projects are present by default. Add your own test project if needed.
- **Debug:**
  - Debug as a class library or reference from a consumer project.

## Conventions & Notes
- **Required Properties:**
  - Models use C# 11+ `required` keyword for essential properties (see `Person`, `Address`).
- **Nullability:**
  - Nullable reference types are enabled except for `ConnectionStrings` (uses `#nullable disable`).
- **Seeding:**
  - Randomizer is seeded for deterministic fake data (see `BogusCustomer.cs`).
- **External Dependencies:**
  - Only `Bogus` NuGet package is referenced.
- **ToString Overrides:**
  - `Customer` overrides `ToString()` for formatted output.

## Example Usage
```csharp
var customers = BogusCustomer.GenerateCustomers(5);
foreach (var customer in customers)
    Console.WriteLine(customer);
```

## Key Files
- `Classes/BogusCustomer.cs`: Data generation logic
- `Models/Customer.cs`, `Models/Person.cs`, `Models/Address.cs`, `Models/Gender.cs`, `Models/ConnectionStrings.cs`
- `Interfaces/IPerson.cs`, `Interfaces/IAddress.cs`

---
_If any conventions or workflows are unclear, please request clarification or examples from the maintainers._

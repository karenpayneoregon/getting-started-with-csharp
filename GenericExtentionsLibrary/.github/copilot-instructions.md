# Copilot Instructions for AI Agents

## Project Overview
- This is a .NET class library providing generic extension methods for value types and comparables.
- Main file: `Extensions.cs` contains all extension methods.
- Project targets .NET 9.0, but code is compatible with earlier .NET versions.

## Key Patterns & Conventions
- All extension methods are static and reside in the `GenericExtensionsLibrary.Extensions` class.
- Naming: Methods use `Between`, `IsBetween`, `BetweenExclusive`, and `IsBetweenExclusive` for inclusive/exclusive range checks.
- Methods are generic and constrained to value types (`struct`) or types implementing `IComparable<T>`.
- XML documentation is present for all public methods; maintain this for new methods.

## Developer Workflows
- **Build:** Use `dotnet build` in the project root.
- **Test:** No tests are present; if adding, use standard .NET test projects and reference this library.
- **Debug:** Attach to a consumer project or use a test harness; no special debug setup required.

## Integration & Usage
- No external dependencies.
- Designed for easy inclusion in other .NET projects via project or DLL reference.
- No cross-component or service boundaries; all logic is in a single file/class.

## Contribution Guidelines
- Add new extension methods to `Extensions.cs`.
- Follow the existing method signature and documentation style.
- Keep methods generic and broadly applicable.
- Update this file if new architectural patterns or workflows are introduced.

## References
- See `Extensions.cs` for all implemented patterns.
- See `readme.md` for a brief project description.

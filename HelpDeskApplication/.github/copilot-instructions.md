# Copilot Instructions for HelpDeskApplication

## Project Overview
- **Type:** ASP.NET Core Razor Pages web application (C#, .NET 9.0)
- **Purpose:** Demonstrates help desk info display, directory validation, and secure configuration using key-per-file secrets.
- **Key Features:**
  - Razor Pages UI with Bootstrap styling
  - Help desk contact info dynamically loaded from configuration and displayed in the footer
  - Directory and file settings validated at startup using custom validators
  - Uses Serilog for structured logging
  - Sensitive configuration (connection strings, credentials) loaded from the `Secrets/` directory via key-per-file

## Architecture & Patterns
- **Entry Point:** `Program.cs` configures DI, logging, and loads secrets from `FileSettings.SecretsDirectory` (default: `C:\OED\Secrets`).
- **Configuration:**
  - `appsettings.json` and `appsettings.Development.json` for base config
  - `Secrets/` directory for sensitive values (e.g., `ConnectionString`, `DatabasePassword`)
  - `FileSettings` and `HelpDesk` sections are bound to strongly-typed options
- **Validation:**
  - Custom `IValidateOptions<RequiredDirectories>` ensures required directories exist at startup
- **UI:**
  - Main layout: `Pages/Shared/_Layout.cshtml` (footer logic for help desk info)
  - Pages: `Pages/Index.cshtml`, `Pages/Privacy.cshtml`, `Pages/Error.cshtml`
- **External Libraries:**
  - `Serilog.AspNetCore` for logging
  - `SpecialValidatorsLibrary` (project reference) for custom validation logic

## Developer Workflows
- **Build & Run:**
  - Use Visual Studio or run `dotnet run` in the project directory
  - Launch profiles in `Properties/launchSettings.json` (http/https, dev environment)
- **Secrets Management:**
  - Place secret files in the `Secrets/` directory (see `FileSettings.SecretsDirectory`)
  - Each secret is a separate file (e.g., `ConnectionString`, `DatabasePassword`)
- **Logging:**
  - Logs output to console (Serilog)
- **Razor Pages:**
  - Use dependency injection for config via `IOptionsSnapshot<T>`
  - UI logic in `Pages/*.cshtml.cs`, markup in `Pages/*.cshtml`

## Project-Specific Conventions
- **Key-per-file secrets:** All sensitive config is loaded from files in `Secrets/` (not from user secrets or environment vars)
- **Help desk info:** Always reference via config binding, not hardcoded
- **Validation:** Use `ValidateOnStart` for options classes that require directory/file checks
- **Footer logic:** Help desk contact info is dynamically rendered in `_Layout.cshtml` using injected config

## Examples
- To add a new secret: create a file in `Secrets/` with the secret name and value
- To add a new config-bound class: update `appsettings.json` and bind in `Program.cs`
- To add a new page: add a `.cshtml` and `.cshtml.cs` in `Pages/`, update navigation in `_Layout.cshtml` if needed

## Key Files & Directories
- `Program.cs`: App startup, DI, config, logging
- `Pages/`: Razor Pages UI
- `Pages/Shared/_Layout.cshtml`: Main layout, help desk info logic
- `Secrets/`: Key-per-file secrets (required for app to run)
- `appsettings.json`, `appsettings.Development.json`: App configuration
- `HelpDeskApplication.csproj`: Project file, dependencies

---
For more details, see code comments in `Program.cs` and `_Layout.cshtml`.

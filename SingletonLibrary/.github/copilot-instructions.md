# Copilot Instructions for SingletonLibrary

## Project Overview
- **Purpose:** Provides helper classes for managing colors associated with seasons, using the Singleton pattern for configuration and color management.
- **Key Concepts:**
  - Singleton pattern is used for `AppConfiguration` and `ColorsHelper` to ensure a single instance throughout the app.
  - Seasonal color logic is centralized in `SeasonColorHelper`.
  - Configuration is loaded via `JsonConfiguration` (requires `ConsoleConfigurationLibrary` NuGet package).

## Architecture & Patterns
- **Singletons:**
  - `AppConfiguration.Instance` and `ColorsHelper.Instance` are the only access points for their respective services.
  - Private constructors and `Lazy<T>` are used for thread-safe instantiation.
- **Seasonal Color Flow:**
  - `ColorsHelper` uses `SeasonColorHelper.GetSeasonColor()` to determine the color for the current season.
  - `SeasonColorHelper` maps `Season` enum values to `System.Drawing.Color`.
- **Configuration:**
  - `AppConfiguration` exposes a `HelpDesk` property, loaded from configuration via `JsonConfiguration.ReadSection<HelpDesk>(...)`.
  - `JsonConfiguration` expects configuration files compatible with `ConsoleConfigurationLibrary`.

## Developer Workflows
- **Build:**
  - Standard .NET build: `dotnet build` from the project root.
- **Debug:**
  - Attach a debugger to any consumer of this library; no special steps required.
- **Test:**
  - No tests are present in this repo. If adding, follow standard .NET test project conventions.

## Project-Specific Conventions
- **Namespace:** All code is under `SingletonLibrary` (with sub-namespaces for `Classes` and `Models`).
- **Enums:** `Season` enum defines `Winter`, `Spring`, `Summer`, `Autumn`.
- **Color Mapping:** Only the four seasons are mapped; fallback is `Color.Gray`.
- **Configuration:**
  - `HelpDesk` model expects `Phone` and `Email` fields in configuration.
  - If not found, defaults to `Unknown` (see implementation for details).

## Key Files
- `Classes/ColorsHelper.cs`: Singleton for color logic.
- `Classes/SeasonColorHelper.cs`: Static helper for season-to-color mapping.
- `Classes/AppConfiguration.cs`: Singleton for app configuration.
- `Classes/JsonConfiguration.cs`: Static config loader (requires external NuGet package).
- `Models/HelpDesk.cs`: Model for help desk contact info.

## External Dependencies
- `ConsoleConfigurationLibrary` NuGet package is required for configuration loading.
- `System.Drawing` is used for color representation.

## Example Usage
```csharp
var color = ColorsHelper.Instance.SeasonColor;
var helpDesk = AppConfiguration.Instance.HelpDesk;
```

---

**Tip:** When adding new helpers or configuration models, follow the singleton and static helper patterns as shown. Place new models in `Models/` and helpers in `Classes/`.

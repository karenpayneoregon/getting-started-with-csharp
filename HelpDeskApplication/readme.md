# About

A demonstration for checking if a directory exists using [ValidateOnStart](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.optionsbuilderextensions.validateonstart?view=net-9.0-pp).

## ⚙️ SpecialValidatorsLibrary
This library provides custom validation attributes and logic for ASP.NET Core applications, making it easier to enforce validation rules on configuration options.

## ⚙️ Required directiory

See appsettings.json, `FileSettings` section, `SecretsDirectory` property.

🚫 Before running the application

- Ensure that the directory specified in `SecretsDirectory` exists. If it does not exist, the application will throw an exception at startup.
- Copy the files Email and Phone to the `SecretsDirectory` directory from the secrets folder in the project.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "HelpDesk": {
    "Phone": "555-555-1234",
    "Email": "ServiceDesk@SomeCompany.net"
  },
  "FileSettings": {
    "SecretsDirectory": "C:\\OED\\Secrets"
  }
}
```
## 🛠️ Usage

Program.cs

```csharp
builder.Services.Configure<HelpDesk>(builder.Configuration.GetSection(nameof(HelpDesk)));

var fileSettings = builder.Configuration.GetSection(nameof(FileSettings)).Get<FileSettings>();

// Define the path where key-per-file secrets are stored
var secretsPath = fileSettings.SecretsDirectory;

if (Directory.Exists(secretsPath))
{
    builder.Configuration.AddKeyPerFile(secretsPath, optional: true, reloadOnChange: true);
}

// Bind configuration section to FileSettings
builder.Services.AddOptions<RequiredDirectories>()
    .Bind(builder.Configuration.GetSection(nameof(FileSettings)));

// using IValidateOptions<T>:
builder.Services.AddSingleton<IValidateOptions<RequiredDirectories>, DirectoryOptionsValidation>();
builder.Services.AddOptions<RequiredDirectories>()
    .ValidateOnStart();

```

1. Configure the `HelpDesk` options using the configuration section. Used in Index page and _Layout.cshtml_.
1. `fileSettings` is used to bind the `FileSettings` section of the configuration.
1. `secretsPath` is defined to point to the directory where key-per-file secrets are stored.
1. Check if the `secretsPath` exists. If it does, add key-per-file configuration to the application.
1. Configure the `RequiredDirectories` options using the configuration section.
1. Call `ValidateOnStart` to ensure that the directories specified in `RequiredDirectories` exist at application startup.


## See Also

- [ASP.NET Core startup validation part 1](https://dev.to/karenpayneoregon/aspnet-core-startup-validation-20e7)
- [ASP .NET Core startup validation part 2](https://dev.to/karenpayneoregon/aspnet-core-startup-validation-part-2-3f7m)
# About

This project, along with the class project SingletonLibrary, provides a simple example of the [Singleton pattern](https://en.wikipedia.org/wiki/Singleton_pattern).

The content has been kept simple on purpose for learning purposes. 

# Usage

In this example the properties of `HelpDesk` model are displayed to the console.

Consider a web application where the `HelpDesk` Phone and Email properties are needed in several pages the values are read once and used many times.

## ⚙️ Appsettings.json

```json
{
  "HelpDesk": {
    "Phone": "555-555-1234",
    "Email": "ServiceDesk@SomeCompany.net"
  }
}
```

## 📝 HelpDesk.cs
```csharp
public class HelpDesk
{
    public string Phone { get; set; }
    public string Email { get; set; }
}
```

## 📝 HelpDeskSingleton.cs

The first time `AppConfiguration.Instance.HelpDesk` is invoked, data is read from `appsettings.json` in the private constructor, and the values are assigned to the property `HelpDesk`. Invoke `AppConfiguration.Instance.HelpDesk`  and the HelpDesk property gives back values without reading appsettings.json again.

```csharp
public sealed class AppConfiguration
{
    private static readonly Lazy<AppConfiguration> _lazyInstance = new(() => new AppConfiguration());
    public static AppConfiguration Instance { get; } = _lazyInstance.Value;

    public HelpDesk HelpDesk { get; }

    private AppConfiguration()
    {

        HelpDesk = JsonConfiguration.ReadSection<HelpDesk>(nameof(HelpDesk));

    }
}
```

## ⚠️ Important Note

In the above case, suppose the helpdesk phone number changes; the application will require a restart. In this case [IOptionsMonitor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptionsmonitor-1?view=net-9.0-pp) would be the best option, which is not suitable for a singleton class.

### See Also

[ASP .NET Core IOptionsMonitor Onchange](https://dev.to/karenpayneoregon/asp-net-core-ioptionsmonitor-onchange-5906)
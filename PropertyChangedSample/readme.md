# About

The purpose of this project is to show the C# 13 field keyword, optimize INotifyPropertyChanged, and provide a great example of setting breakpoints and using Visual Studio’s local window to examine data at a stop on a breakpoint.

- An example of using the [INotifyPropertyChanged](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-9.0) interface in C# to notify clients that a property value has changed.
- Uses [field](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/field) keyword which eliminates the need to declare explicit backing fields, leading to cleaner and more concise code.



## Language Version

Uses preview in project file:

```xml
<LangVersion>preview</LangVersion>
<TargetFrameworks>net9.0</TargetFrameworks>
```

## Optimized code to use INotifyPropertyChanged

```csharp
internal partial class Person
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return false;
        }

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
```

### Usage

Example

```csharp
internal partial class Person : Base, INotifyPropertyChanged
{
    public string FirstName
    {
        get => field.TrimEnd();
        set => SetField(ref field, value, nameof(FirstName));
    }

    public string LastName
    {
        get => field.TrimEnd();
        set => SetField(ref field, value, nameof(LastName));
    }

    public DateTime BirthDate
    {
        get;
        set => SetField(ref field, value, nameof(BirthDate));
    }

    public Gender Gender
    {
        get;
        set => SetField(ref field, value, nameof(Gender));
    }

    public partial string Remarks { get; set; }

}
```

using Bogus;
using CustomersBogusLibrary.Classes;
using CustomersBogusLibrary.Models;

using Person = CustomersBogusLibrary.Models.Person;

namespace CustomersBogusApp.Classes;

/// <summary>
/// Provides a singleton instance to manage application data, including a collection of customers and people.
/// </summary>
/// <remarks>
/// This class ensures a single instance is created and used throughout the application.
/// It initializes collections of customers and people using the <see cref="BogusOperations.GenerateCustomers(int)"/> 
/// and <see cref="BogusOperations.GeneratePeople(int)"/> methods, respectively.
/// </remarks>
public sealed class AppData
{
    private static readonly Lazy<AppData> Lazy = new(() => new AppData());

    public static AppData Instance => Lazy.Value;

    public List<Customer> Customers { get; set; }

    public List<Person> People { get; set; }
    
    // For Serilog
    public string LogFileName => "Log.txt";

    /// <summary>
    /// Initializes a new instance of the <see cref="AppData"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor is private to enforce the singleton pattern. It initializes the
    /// <see cref="Customers"/> and <see cref="People"/> properties with data generated
    /// by the <see cref="BogusOperations.GenerateCustomers(int)"/> and
    /// <see cref="BogusOperations.GeneratePeople(int)"/> methods, respectively.
    /// </remarks>
    private AppData()
    {
        Customers = BogusOperations.GenerateCustomers();
        People = BogusOperations.GeneratePeople(50);
    }
}
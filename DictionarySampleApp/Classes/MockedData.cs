using ConsoleConfigurationLibrary.Classes;
using DictionarySampleApp.Models;

namespace DictionarySampleApp.Classes;
/// <summary>
/// Performs data operations.
/// </summary>
internal class MockedData
{
    // here for demonstration purposes
    public static void GetSettings()
    {
        Console.WriteLine(AppConnections.Instance.MainConnection);
        Console.WriteLine(EntitySettings.Instance.CreateNew);
    }

    /// <summary>
    /// Provides a dictionary of fruits where the key represents a unique identifier 
    /// and the value represents the name of the fruit.
    /// </summary>
    public static Dictionary<int, string> Fruits => new()
    {
        [1] = "Pears",
        [2] = "Grapes",
        [3] = "Cherries",
        [4] = "Apples",
        [5] = "Bananas",
        [6] = "Mangoes",
        [7] = "Oranges"
    };

    /// <summary>
    /// Adds a new fruit to the specified dictionary with a unique key.
    /// </summary>
    /// <param name="dict">
    /// The dictionary to which the fruit will be added. The keys represent unique identifiers, 
    /// and the values represent the names of the fruits.
    /// </param>
    /// <param name="fruit">
    /// The name of the fruit to add to the dictionary.
    /// </param>
    /// <remarks>
    /// Not safe for concurrent use.
    /// </remarks>
    public static void AddFruit(Dictionary<int, string> dict, string fruit)
    {
        int nextKey = dict.Keys.Max() + 1;
        dict[nextKey] = fruit;
    }

    /// <summary>
    /// Gets a predefined list of people with their details such as ID, name, date of birth, and gender.
    /// </summary>
    /// <remarks>
    /// Each <see cref="Person"/> object in the list contains the following properties:
    /// <list type="bullet">
    /// <item><description><see cref="Person.Id"/>: The unique identifier for the person.</description></item>
    /// <item><description><see cref="Person.FirstName"/>: The first name of the person.</description></item>
    /// <item><description><see cref="Person.LastName"/>: The last name of the person.</description></item>
    /// <item><description><see cref="Person.DateOfBirth"/>: The date of birth of the person.</description></item>
    /// <item><description><see cref="Person.Gender"/>: The gender of the person, represented by the <see cref="Gender"/> enumeration.</description></item>
    /// </list>
    /// </remarks>
    /// <returns>A <see cref="List{T}"/> of <see cref="Person"/> objects.</returns>
    public static List<Person> People =>
    [
        new() { Id = 1, FirstName = "Alice", LastName = "Smith", DateOfBirth = new DateOnly(1985, 6, 12), Gender = Gender.Female },
        new() { Id = 2, FirstName = "Bob", LastName = "Johnson", DateOfBirth = new DateOnly(1990, 3, 25), Gender = Gender.Male },
        new() { Id = 3, FirstName = "Catherine", LastName = "Brown", DateOfBirth = new DateOnly(1978, 11, 2), Gender = Gender.Female },
        new() { Id = 4, FirstName = "David", LastName = "Wilson", DateOfBirth = new DateOnly(2000, 7, 9), Gender = Gender.Male },
        new() { Id = 5, FirstName = "Ella", LastName = "Taylor", DateOfBirth = new DateOnly(1995, 1, 14), Gender = Gender.Female }
    ];

    /// <summary>
    /// Provides a dictionary mapping unique IDs to corresponding Person objects.
    /// Each ID serves as a key for quick access to a specific Person.
    /// </summary>
    public static Dictionary<int, Person> PersonDictionary = People
        .Select((person, index) => new
        {
            Key = index + 1, 
            Value = person
        })
        .ToDictionary(x => x.Key, x => x.Value);

}

using DictionarySampleApp.Classes;

namespace DictionarySampleApp;
internal partial class Program
{
    static void Main(string[] args)
    {
        SpectreConsoleHelpers.ExitPrompt();
    }


    private static void BasicMockupSample1()
    {
        Dictionary<int, string> fruits = MockedData.Fruits;


        foreach (KeyValuePair<int, string> kvp in fruits)
        {
            Console.WriteLine($"Key: {kvp.Key}, Fruit: {kvp.Value}");
        }
    }

    /// <summary>
    /// Demonstrates the deconstruction of a dictionary into key-value pairs 
    /// and outputs the keys and values to the console.
    /// </summary>
    /// <remarks>
    /// This method retrieves a dictionary of fruits from <see cref="DictionarySampleApp.Classes.MockedData.Fruits"/> 
    /// and iterates through its entries, deconstructing each entry into its key and value.
    /// </remarks>
    private static void BasicMockupDeconstructSample()
    {
        Dictionary<int, string> fruits = MockedData.Fruits;

        // Deconstructing the dictionary into key-value pairs
        foreach (var (key, fruit) in fruits)
        {
            Console.WriteLine($"Key: {key}, Fruit: {fruit}");
        }
    }

    /// <summary>
    /// Iterates through the <see cref="MockedData.PersonDictionary"/> collection, 
    /// displaying each person's index, first name, last name, date of birth, and gender in a formatted output.
    /// </summary>
    /// <remarks>
    /// The method uses the <c>Index</c> extension method to enumerate the dictionary with indices.
    /// </remarks>
    private static void PersonMockupEnumerableIndex()
    {
        foreach (var (index, person) in MockedData.PersonDictionary.Index())
        {
            Console.WriteLine($"{index,-4}" +
                              $"{person.Value.FirstName,-12}" +
                              $"{person.Value.LastName,-12}" +
                              $"{person.Value.DateOfBirth,-14:MM/dd/yyyy}" +
                              $"{person.Value.Gender}");
        }
    }

    /// <summary>
    /// Iterates through the <see cref="MockedData.PersonDictionary"/> and writes each person's details
    /// (index, first name, last name, date of birth, and gender) to the console in a formatted manner.
    /// </summary>
    private static void PersonMockupDeconstruct()
    {
        foreach (var (index, person) in MockedData.PersonDictionary)
        {
            Console.WriteLine($"{index,-4}" +
                              $"{person.FirstName,-12}" +
                              $"{person.LastName,-12}" +
                              $"{person.DateOfBirth,-14:MM/dd/yyyy}" +
                              $"{person.Gender}");
        }
    }
}

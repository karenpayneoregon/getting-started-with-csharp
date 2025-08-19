using PropertyChangedSample.Classes;
using PropertyChangedSample.Models;

namespace PropertyChangedSample;
internal partial class Program
{
    private static void Main()
    {

        var person = BogusOperations.PersonsList(1).FirstOrDefault();

        person.FirstName = "Karen";
        person.LastName = "Payne";
        person.BirthDate = new DateTime(1980, 1, 1);
        person.Gender = Gender.Female;

        var personDump = ObjectDumper.Dump(person);
        Console.WriteLine(personDump);

        SpectreConsoleHelpers.ExitPrompt();
    }
}

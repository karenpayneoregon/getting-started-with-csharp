using CustomersBogusApp.Classes;
using CustomersBogusApp.Classes.Helpers;

namespace CustomersBogusApp;
internal partial class Program
{
    /// <summary>
    /// The lesson here is to place code into a class in this case for learning looping
    /// </summary>
    private static void Main()
    {
        CustomersForAndWhile.TraditionalForStatement();
        CustomersForAndWhile.TraditionalForEachStatement();
        CustomersForAndWhile.ForEachWithIndexStatement();
        CustomersForAndWhile.WhileLoop();

        Console.WriteLine();

        /*
         * We could eliminate the need for variable but this way
         * we can debug and see the results
         */
        var people = AppData.Instance.People;
        PersonGrouping.DisplayGroupedPeopleByStateUsingLinq(people);

        SpectreConsoleHelpers.ExitPrompt();
    }
}

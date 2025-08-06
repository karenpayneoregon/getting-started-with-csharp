using CustomersBogusLibrary.Models;
using Spectre.Console;
using static CustomersBogusApp.Classes.Helpers.SpectreConsoleHelpers;

namespace CustomersBogusApp.Classes;

/// <summary>
/// Provides functionality for grouping and displaying a list of <see cref="Person"/> objects by their state.
/// </summary>
/// <remarks>
/// This class contains methods to group people by their state using different approaches, such as lambda expressions and LINQ.
/// The grouped results are displayed, with each group ordered alphabetically by state and the people within each group sorted by their last name.
/// </remarks>
public static class PersonGrouping
{

    /// <summary>
    /// Groups a list of people by their state using a lambda expression and displays the grouped results.
    /// </summary>
    /// <param name="people">
    /// A list of <see cref="Person"/> objects to be grouped by their state.
    /// </param>
    /// <remarks>
    /// This method uses a lambda expression to group people by their state, orders the groups alphabetically by state,
    /// and then displays each group along with the people in it, sorted by their last name.
    /// </remarks>
    public static void DisplayGroupedPeopleByStateUsingLambda(List<Person> people)
    {

        PrintMethodName();

        var grouped = people
            .GroupBy(p => p.Address.State)
            .OrderBy(g => g.Key); 

        foreach (var group in grouped)
        {
            AnsiConsole.MarkupLine($"[{Color.PaleGreen1}]{group.Key}[/]");

            foreach (var person in group.OrderBy(p => p.LastName))
            {
                Console.WriteLine($"   {person.LastName, -12}{person.FirstName, -10} {person.Address.City}");
            }

            Console.WriteLine();
        }
    }

    /// <summary>
    /// Groups a list of people by their state using LINQ and displays the grouped results.
    /// </summary>
    /// <param name="people">
    /// A list of <see cref="Person"/> objects to be grouped by their state.
    /// </param>
    /// <remarks>
    /// This method uses LINQ to group people by their state, orders the groups alphabetically by state,
    /// and then displays each group along with the people in it, sorted by their last name.
    /// </remarks>
    public static void DisplayGroupedPeopleByStateUsingLinq(List<Person> people)
    {

        PrintMethodName();

        var grouped =
            from person in people
            group person by person.Address.State into stateGroup
            orderby stateGroup.Key
            select stateGroup;

        foreach (var group in grouped)
        {
            AnsiConsole.MarkupLine($"[{Color.PaleGreen1}]{group.Key}[/]");

            foreach (var person in group.OrderBy(p => p.LastName))
            {
                Console.WriteLine($"   {person.LastName,-12}{person.FirstName,-10} {person.Address.City}");
            }

            Console.WriteLine();
        }
    }
}

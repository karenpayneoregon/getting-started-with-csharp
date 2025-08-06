using CustomersBogusLibrary.Models;
using Spectre.Console;
using System;
using static CustomersBogusApp.Classes.Helpers.SpectreConsoleHelpers;


namespace CustomersBogusApp.Classes;

/// <summary>
/// Demonstrates the use of various looping constructs in C#
/// to iterate through and display collections of customers.
/// </summary>
/// <remarks>
/// This class provides examples of traditional for loops, foreach loops, 
/// indexed foreach loops, and while loops, with specific formatting for 
/// customers based on their gender.
/// </remarks>
internal class CustomersForAndWhile
{
    private static Color _femaleColor = Color.DeepPink3;

    /// <summary>
    /// Iterates through a collection of customers using a traditional for loop
    /// and displays their details in a formatted manner.
    /// </summary>
    /// <remarks>
    /// Customers with a gender of <see cref="Gender.Female"/> are displayed 
    /// with a specific color for better visual distinction.
    /// </remarks>
    public static void TraditionalForStatement()
    {

        PrintMethodName();

        var customers = AppData.Instance.Customers;

        for (int index = 0; index < customers.Count; index++)
        {
            if (customers[index].Gender == Gender.Female)
            {
                AnsiConsole.MarkupLine($"[{_femaleColor}]{customers[index].Id,-5}{customers[index].FirstName,-10}{customers[index].LastName,-15}{customers[index].Gender,-10}{customers[index].BirthDay:MM/dd/yyyy}[/]");
            }
            else
            {
                AnsiConsole.MarkupLine($"{customers[index].Id,-5}{customers[index].FirstName,-10}{customers[index].LastName,-15}{customers[index].Gender,-10}{customers[index].BirthDay:MM/dd/yyyy}");
            }
        }

        Console.WriteLine();

    }

    /// <summary>
    /// Iterates through a collection of customers using a traditional foreach loop
    /// and displays their details in a formatted manner.
    /// </summary>
    /// <remarks>
    /// Customers with a gender of <see cref="Gender.Female"/> are displayed 
    /// with a specific color for better visual distinction.
    /// </remarks>
    public static void TraditionalForEachStatement()
    {

        PrintMethodName();

        var customers = AppData.Instance.Customers;

        foreach (var customer in customers)
        {
            if (customer.Gender == Gender.Female)
            {
                AnsiConsole.MarkupLine($"[{_femaleColor}]{customer.Id,-5}{customer.FirstName,-10}{customer.LastName,-15}{customer.Gender,-10}{customer.BirthDay:MM/dd/yyyy}[/]");
            }
            else
            {
                AnsiConsole.MarkupLine($"{customer.Id,-5}{customer.FirstName,-10}{customer.LastName,-15}{customer.Gender,-10}{customer.BirthDay:MM/dd/yyyy}");
            }
        }

        Console.WriteLine();

    }

    /// <summary>
    /// Iterates through a collection of customers using a foreach loop with index
    /// and displays their details in a formatted manner.
    /// </summary>
    /// <remarks>
    /// This method utilizes an indexed foreach loop to provide both the index 
    /// and the customer object during iteration. Customers with a gender of 
    /// <see cref="Gender.Female"/> are displayed with a specific color for 
    /// better visual distinction.
    /// </remarks>
    public static void ForEachWithIndexStatement()
    {

        PrintMethodName();

        var customers = AppData.Instance.Customers;

        foreach (var (index, customer) in customers.Index())
        {
            if (customer.Gender == Gender.Female)
            {
                AnsiConsole.MarkupLine($"[{_femaleColor}]{index,-5}{customer.FirstName,-10}{customer.LastName,-15}{customer.Gender,-10}{customer.BirthDay:MM/dd/yyyy}[/]");
            }
            else
            {
                AnsiConsole.MarkupLine($"{index,-5}{customer.FirstName,-10}{customer.LastName,-15}{customer.Gender,-10}{customer.BirthDay:MM/dd/yyyy}");
            }
        }

        Console.WriteLine();

    }

    /// <summary>
    /// Iterates through a collection of customers using a while loop
    /// and displays their details in a formatted manner.
    /// </summary>
    /// <remarks>
    /// Customers with a gender of <see cref="Gender.Female"/> are displayed 
    /// with a specific color for better visual distinction.
    /// </remarks>
    public static void WhileLoop()
    {
        PrintMethodName();

        var customers = AppData.Instance.Customers;
        int index = 0;

        while (index < customers.Count)
        {
            if (customers[index].Gender == Gender.Female)
            {
                AnsiConsole.MarkupLine($"[{_femaleColor}]{index,-5}{customers[index].Id,-5}{customers[index].FirstName,-10}{customers[index].LastName,-15}{customers[index].Gender,-10}{customers[index].BirthDay:MM/dd/yyyy}[/]");
            }
            else
            {
                AnsiConsole.MarkupLine($"{index,-5}{customers[index].Id,-5}{customers[index].FirstName,-10}{customers[index].LastName,-15}{customers[index].Gender,-10}{customers[index].BirthDay:MM/dd/yyyy}");
            }

            index++;
        }


        Console.WriteLine();

    }

}

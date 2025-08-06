using Bogus;
using Bogus.DataSets;
using CustomersBogusLibrary.Models;

namespace CustomersBogusLibrary.Classes;

public class BogusOperations
{
    /// <summary>
    /// Generates a list of fake customer data.
    /// </summary>
    /// <param name="count">
    /// The number of customers to generate. Defaults to 10 if not specified.
    /// </param>
    /// <returns>
    /// A list of <see cref="Customer"/> objects populated with random data.
    /// </returns>
    /// <remarks>
    /// * This method was created by GitHub Copilot using the following prompt: BogusCustomers.prompt.md
    /// * FirstName was not gender aware which comes from training so Karen altered the code
    /// </remarks>
    public static List<Customer> GenerateCustomers(int count = 10)
    {
        Randomizer.Seed = new(338);

        var id = 1;

        var faker = new Faker<Customer>()
            .RuleFor(c => c.Id, f => id++)
            .RuleFor(c => c.Gender, f => f.PickRandom<Gender>())
            .RuleFor(c => c.FirstName, (f, c) => f.Name.FirstName((Name.Gender?)c.Gender))
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.BirthDay, f => DateOnly.FromDateTime(f.Date.Past(40, DateTime.Today.AddYears(-18))))
            .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.FirstName, c.LastName));

        return faker.Generate(count);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public static List<Models.Person> GeneratePeople(int count = 10)
    {
        
        Randomizer.Seed = new(339);

        int personId = 1;

        // Address Faker
        var addressFaker = new Faker<Models.Address>()
            .RuleFor(a => a.Street, f => f.Address.StreetAddress())
            .RuleFor(a => a.City, f => f.Address.City())
            .RuleFor(a => a.State, f => f.Address.StateAbbr())
            .RuleFor(a => a.PostalCode, f => f.Address.ZipCode());

        // Person Faker
        var personFaker = new Faker<Models.Person>()
            .RuleFor(p => p.Id, f => personId++)
            .RuleFor(p => p.FirstName, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.Address, f => addressFaker.Generate());

        return personFaker.Generate(count);
    }
}

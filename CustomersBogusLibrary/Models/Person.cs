using CustomersBogusLibrary.Interfaces;

namespace CustomersBogusLibrary.Models;

public class Person : IPerson
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required Address Address { get; set; }
}
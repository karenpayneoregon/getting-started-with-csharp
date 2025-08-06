using CustomersBogusLibrary.Interfaces;

namespace CustomersBogusLibrary.Models;

public class Address : IAddress
{
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string PostalCode { get; set; }
}
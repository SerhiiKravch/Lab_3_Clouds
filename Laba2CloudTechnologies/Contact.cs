using Microsoft.Azure.Cosmos.Table;

namespace Laba2CloudTechnologies;

public class Contact : TableEntity
{
    public Contact() { }

    public Contact(string lastName, string firstName)
    {
        PartitionKey = lastName;
        RowKey = firstName;
    }

    public string middleName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhotoUrl { get; set; } = null!;
    public string PhoneNumbers { get; set; } = null!; // JSON-serialized list
}
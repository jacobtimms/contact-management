namespace ContactManagementSolution.Tests.Features.Fund.ListContacts.V1;

public class TestData
{
    public static readonly Entities.Fund Fund = new()
    {
        Id = Guid.NewGuid(), Name = "Fund A"
    };
    
    public static readonly List<Entities.Contact> Contacts =
    [
        new() { Id = Guid.NewGuid(), Name = "John Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890" },
        new() { Id = Guid.NewGuid(), Name = "Jane Smith", Email = "jane.smith@example.com", PhoneNumber = "098-765-4321" }
    ];
    
    public static readonly List<Entities.FundContact> FundContacts =
    [
        new() { FundId = Fund.Id, ContactId = Contacts[0].Id },
        new() { FundId = Fund.Id, ContactId = Contacts[1].Id }
    ];
}
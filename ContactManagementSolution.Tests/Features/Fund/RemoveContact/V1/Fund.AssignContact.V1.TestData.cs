namespace ContactManagementSolution.Tests.Features.Fund.RemoveContact.V1;

public class TestData
{
    public static readonly Entities.Fund Fund = new()
    {
        Id = Guid.NewGuid(), Name = "Fund A"
    };

    public static readonly Entities.Contact Contact = new()
    {
        Id = Guid.NewGuid(), Name = "John Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890"
    };
}
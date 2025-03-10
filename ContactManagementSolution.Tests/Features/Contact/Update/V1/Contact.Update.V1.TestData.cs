namespace ContactManagementSolution.Tests.Features.Contact.Update.V1;

public class TestData
{
    public static readonly Entities.Contact Contact = new()
    {
        Id = Guid.NewGuid(), Name = "Jane Smith", Email = "jane.smith@example.com", PhoneNumber = "098-765-4321"
    };
}
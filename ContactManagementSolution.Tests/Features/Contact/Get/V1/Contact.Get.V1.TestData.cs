namespace ContactManagementSolution.Tests.Features.Contact.Get.V1;

public class TestData
{
    public static readonly List<Entities.Contact> Contacts =
    [
        new() { Id = Guid.NewGuid(), Name = "John Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890" },
        new() { Id = Guid.NewGuid(), Name = "Jane Smith", Email = "jane.smith@example.com", PhoneNumber = "098-765-4321" }
    ];
}
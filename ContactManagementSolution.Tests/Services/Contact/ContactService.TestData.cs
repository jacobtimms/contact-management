namespace ContactManagementSolution.Tests.Services.Contact;

using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;

public class TestData
{
    public static readonly List<Entities.Contact> Contacts =
    [
        new() { Id = Guid.NewGuid(), Name = "John Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890" },
        new() { Id = Guid.NewGuid(), Name = "Jane Smith", Email = "jane.smith@example.com", PhoneNumber = "098-765-4321" }
    ];
    
    public static Mock<DbSet<Entities.Contact>> GetMockFundsDbSet()
    {
        return new List<Entities.Contact>(Contacts).AsQueryable().BuildMockDbSet();
    }
}
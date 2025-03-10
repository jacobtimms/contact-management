namespace ContactManagementSolution.Tests.Services.Fund;

using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;

public class TestData
{
    public static readonly Entities.FundContact FundContact = new()
    {
        FundId = Guid.NewGuid(), ContactId = Guid.NewGuid()
    };
    
    public static readonly List<Entities.Fund> Funds =
    [
        new() { Id = Guid.NewGuid(), Name = "Fund A" },
        new() { Id = Guid.NewGuid(), Name = "Fund B" },
        new() { Id = Guid.NewGuid(), Name = "Fund C" },
        new() { Id = Guid.NewGuid(), Name = "Fund D" },
        new() { Id = Guid.NewGuid(), Name = "Fund E" }
    ];
    
    public static Mock<DbSet<Entities.Fund>> GetMockFundsDbSet()
    {
        return new List<Entities.Fund>(Funds).AsQueryable().BuildMockDbSet();
    }
}
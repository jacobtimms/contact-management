namespace ContactManagementSolution.Tests.Features.Fund.Get.V1;

public class TestData
{
    public static readonly List<Entities.Fund> Funds =
    [
        new() { Id = Guid.NewGuid(), Name = "Fund A" },
        new() { Id = Guid.NewGuid(), Name = "Fund B" },
        new() { Id = Guid.NewGuid(), Name = "Fund C" },
        new() { Id = Guid.NewGuid(), Name = "Fund D" },
        new() { Id = Guid.NewGuid(), Name = "Fund E" }
    ];
}
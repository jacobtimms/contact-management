namespace ContactManagementSolution.Features.Fund.Get.V1;

public sealed record Response
{
    public required IEnumerable<FundInfo> Funds { get; set; }
}

public sealed record FundInfo
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
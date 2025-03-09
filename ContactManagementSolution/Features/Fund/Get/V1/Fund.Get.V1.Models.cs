namespace ContactManagementSolution.Features.Fund.Get.V1;

public sealed record Response
{
    public required IEnumerable<FundData> Funds { get; set; }
}

public sealed record FundData
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
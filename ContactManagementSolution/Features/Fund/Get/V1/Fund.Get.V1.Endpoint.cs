namespace ContactManagementSolution.Features.Fund.Get.V1;

using FastEndpoints;

public sealed class Endpoint(FundService service) : EndpointWithoutRequest<Response, Mapper>
{
    public override void Configure()
    {
        Get("/fund");
        Version(1);
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var records = await service.GetAllFundsAsync(ct);
        await SendMappedAsync(records, ct: ct);
    }
}
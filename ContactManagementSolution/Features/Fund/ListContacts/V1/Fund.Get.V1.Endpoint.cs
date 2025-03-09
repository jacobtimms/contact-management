namespace ContactManagementSolution.Features.Fund.ListContacts.V1;

using FastEndpoints;

public sealed class Endpoint(FundService service) : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Get("/fund/{id}/contact");
        Version(1);
    }
    
    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        if (!await service.FundExistsAsync(req.Id, ct))
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        var data = await service.ListFundContactsAsync(req.Id, ct);
        await SendMappedAsync(data, ct: ct);
    }
}
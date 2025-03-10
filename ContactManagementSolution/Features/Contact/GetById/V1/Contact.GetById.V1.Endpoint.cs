namespace ContactManagementSolution.Features.Contact.GetById.V1;

using FastEndpoints;

public sealed class Endpoint(IContactService service) : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Get("/contact/{id}");
        Version(1);
    }
    
    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var record = await service.GetContactByIdAsync(req.Id, ct);
        if (record == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendMappedAsync(record, ct: ct);
    }
}
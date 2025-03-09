namespace ContactManagementSolution.Features.Contact.Update.V1;

using FastEndpoints;

public sealed class Endpoint(ContactService service) : EndpointWithMapper<Request, Mapper>
{
    public override void Configure()
    {
        Patch("/contact/{id}");
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
        
        Mapper.ToEntity(req, record);
        await service.UpdateContactAsync(record, ct);

        await SendNoContentAsync(ct);
    }
}
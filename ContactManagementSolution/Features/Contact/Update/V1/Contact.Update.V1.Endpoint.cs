namespace ContactManagementSolution.Features.Contact.Update.V1;

using FastEndpoints;

public sealed class Endpoint(IContactService service) : EndpointWithMapper<Request, Mapper>
{
    public override void Configure()
    {
        Patch("/contact/{id}");
        Version(1);
    }
    
    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var data = await service.GetContactByIdAsync(req.Id, ct);
        if (data == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        Mapper.ToEntity(req, data);
        await service.UpdateContactAsync(data, ct);

        await SendNoContentAsync(ct);
    }
}
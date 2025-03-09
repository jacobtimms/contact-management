using FastEndpoints;

namespace ContactManagementSolution.Features.Contact.Delete.V1;

public sealed class Endpoint(ContactService service) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Delete("/contact/{id}");
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

        await service.DeleteContactAsync(record, ct);
        
        await SendNoContentAsync(ct);
    }
}
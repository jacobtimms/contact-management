namespace ContactManagementSolution.Features.Contact.Delete.V1;

using FastEndpoints;

public sealed class Endpoint(IContactService service) : Endpoint<Request>
{
    public override void Configure()
    {
        Delete("/contact/{id}");
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
        
        if (await service.ContactAssignedToAnyFund(req.Id, ct))
            AddError("Contact cannot be deleted whilst assigned to a fund");
        
        ThrowIfAnyErrors();

        await service.DeleteContactAsync(data, ct);
        
        await SendNoContentAsync(ct);
    }
}
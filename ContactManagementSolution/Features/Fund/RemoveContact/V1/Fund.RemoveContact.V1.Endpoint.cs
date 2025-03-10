namespace ContactManagementSolution.Features.Fund.RemoveContact.V1;

using FastEndpoints;

public sealed class Endpoint(IFundService service) : Endpoint<Request>
{
    public override void Configure()
    {
        Delete("/fund/{id}/contact/{contactId}");
        Version(1);
    }
    
    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        if (!await service.FundExistsAsync(req.Id, ct))
            AddError(r => r.Id, "Fund not found");

        if (!await service.ContactExistsAsync(req.ContactId, ct))
            AddError(r => r.ContactId, "Contact not found");
        
        ThrowIfAnyErrors();

        var entity = await service.GetFundContactAsync(req.Id, req.ContactId, ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        await service.RemoveFundContactAsync(entity, ct);

        await SendNoContentAsync(ct);
    }
}
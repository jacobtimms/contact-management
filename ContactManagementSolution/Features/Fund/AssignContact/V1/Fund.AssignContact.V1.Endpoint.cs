namespace ContactManagementSolution.Features.Fund.AssignContact.V1;

using FastEndpoints;

public sealed class Endpoint(IFundService service) : Endpoint<Request>
{
    public override void Configure()
    {
        Post("/fund/{id}/contact");
        Version(1);
    }
    
    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        if (!await service.FundExistsAsync(req.Id, ct))
            AddError(r => r.Id, "Fund not found");

        if (!await service.ContactExistsAsync(req.ContactId, ct))
            AddError(r => r.ContactId, "Contact not found");

        if (await service.FundContactExistsAsync(req.Id, req.ContactId, ct))
            AddError("Contact already assigned to the fund");
        
        ThrowIfAnyErrors();
        
        await service.AddFundContactAsync(req.Id, req.ContactId, ct);

        await SendNoContentAsync(ct);
    }
}
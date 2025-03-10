namespace ContactManagementSolution.Features.Contact.Create.V1;

using FastEndpoints;

public sealed class Endpoint(IContactService service) : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Post("/contact");
        Version(1);
    }
    
    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var record = await service.CreateContactAsync(Map.ToEntity(req), ct);
        if (record == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendCreatedAtAsync<GetById.V1.Endpoint>(new { record.Id }, 
            await Map.FromEntityAsync(record, ct), cancellation: ct);
    }
}
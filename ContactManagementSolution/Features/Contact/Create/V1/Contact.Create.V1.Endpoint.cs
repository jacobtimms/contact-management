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
        var data = await service.CreateContactAsync(Map.ToEntity(req), ct);

        await SendCreatedAtAsync<GetById.V1.Endpoint>(new { data.Id }, 
            await Map.FromEntityAsync(data, ct), cancellation: ct);
    }
}
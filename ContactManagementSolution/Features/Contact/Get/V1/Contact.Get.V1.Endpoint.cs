namespace ContactManagementSolution.Features.Contact.Get.V1;

using FastEndpoints;

public sealed class Endpoint(IContactService service) : EndpointWithoutRequest<Response, Mapper>
{
    public override void Configure()
    {
        Get("/contact");
        Version(1);
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var data = await service.GetAllContactsAsync(ct);
        await SendMappedAsync(data, ct: ct);
    }
}
namespace ContactManagementSolution.Features.Contact.Get.V1;

using Fund;
using FastEndpoints;

public sealed class Endpoint(ContactService service) : EndpointWithoutRequest<Response, Mapper>
{
    public override void Configure()
    {
        Get("/contact");
        Version(1);
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var records = await service.GetAllContactsAsync(ct);
        await SendMappedAsync(records, ct: ct);
    }
}
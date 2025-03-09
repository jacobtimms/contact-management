using FastEndpoints;

namespace ContactManagementSolution.Features.Contact.GetById.V1;

public sealed class Mapper : Mapper<Request, Response, Entities.Contact>
{
    public override Response FromEntity(Entities.Contact e)
    {
        return new Response
        {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber
        };
    }

    public override Task<Response> FromEntityAsync(Entities.Contact e, CancellationToken ct = default)
    {
        return Task.FromResult(FromEntity(e));
    }
}
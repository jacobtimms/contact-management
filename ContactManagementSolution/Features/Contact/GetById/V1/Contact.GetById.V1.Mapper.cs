namespace ContactManagementSolution.Features.Contact.GetById.V1;

using Entities;
using FastEndpoints;

public sealed class Mapper : Mapper<Request, Response, Contact>
{
    public override Response FromEntity(Contact e)
    {
        return new Response
        {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber
        };
    }

    public override Task<Response> FromEntityAsync(Contact e, CancellationToken ct = default)
    {
        return Task.FromResult(FromEntity(e));
    }
}
namespace ContactManagementSolution.Features.Contact.Create.V1;

using Entities;
using FastEndpoints;

public sealed class Mapper : Mapper<Request, Response, Contact>
{
    public override Response FromEntity(Contact e)
    {
        return new Response
        {
                Id = e.Id
        };
    }

    public override Task<Response> FromEntityAsync(Contact e, CancellationToken ct = default)
    {
        return Task.FromResult(FromEntity(e));
    }

    public override Contact ToEntity(Request r)
    {
        return new Contact
        {
            Name = r.Name,
            Email = r.Email,
            PhoneNumber = r.PhoneNumber
        };
    }
}
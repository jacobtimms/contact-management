namespace ContactManagementSolution.Features.Contact.Create.V1;

using FastEndpoints;

public sealed class Mapper : Mapper<Request, Response, Entities.Contact>
{
    public override Response FromEntity(Entities.Contact e)
    {
        return new Response
        {
                Id = e.Id
        };
    }

    public override Task<Response> FromEntityAsync(Entities.Contact e, CancellationToken ct = default)
    {
        return Task.FromResult(FromEntity(e));
    }

    public override Entities.Contact ToEntity(Request r)
    {
        return new Entities.Contact
        {
            Name = r.Name,
            Email = r.Email,
            PhoneNumber = r.PhoneNumber
        };
    }
}
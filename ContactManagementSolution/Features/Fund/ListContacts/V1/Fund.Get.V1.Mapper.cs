namespace ContactManagementSolution.Features.Fund.ListContacts.V1;

using Entities;
using FastEndpoints;

public sealed class Mapper : Mapper<Request, Response, IEnumerable<Contact>>
{
    public override Response FromEntity(IEnumerable<Contact> e)
    {
        return new Response
        {
            Contacts = e.Select(record => new ContactData
            {
                Id = record.Id,
                Name = record.Name
            })
        };
    }

    public override Task<Response> FromEntityAsync(IEnumerable<Contact> e, CancellationToken ct = default)
    {
        return Task.FromResult(FromEntity(e));
    }
}
namespace ContactManagementSolution.Features.Contact.Get.V1;

using FastEndpoints;

public sealed class Mapper : ResponseMapper<Response, IEnumerable<Entities.Contact>>
{
    public override Response FromEntity(IEnumerable<Entities.Contact> e)
    {
        return new Response
        {
            Contacts = e.Select(record => new ContactInfo
            {
                Id = record.Id,
                Name = record.Name,
                Email = record.Email,
                PhoneNumber = record.PhoneNumber
            })
        };
    }

    public override Task<Response> FromEntityAsync(IEnumerable<Entities.Contact> e, CancellationToken ct = default)
    {
        return Task.FromResult(FromEntity(e));
    }
}
namespace ContactManagementSolution.Features.Fund.Get.V1;

using FastEndpoints;

public sealed class Mapper : ResponseMapper<Response, IEnumerable<Entities.Fund>>
{
    public override Response FromEntity(IEnumerable<Entities.Fund> e)
    {
        return new Response
        {
            Funds = e.Select(record => new FundInfo
            {
                Id = record.Id,
                Name = record.Name
            })
        };
    }

    public override Task<Response> FromEntityAsync(IEnumerable<Entities.Fund> e, CancellationToken ct = default)
    {
        return Task.FromResult(FromEntity(e));
    }
}
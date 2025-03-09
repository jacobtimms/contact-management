namespace ContactManagementSolution.Features.Fund;

using Microsoft.EntityFrameworkCore;

public class FundService(IFundDbContext context)
{
    public async Task<IEnumerable<Entities.Fund>> GetAllFundsAsync(CancellationToken ct = default)
    {
        return await context.Funds.ToListAsync(cancellationToken: ct);
    }
}

public interface IFundDbContext
{
    DbSet<Entities.Fund> Funds { get; set; }
    DbSet<Entities.Contact> Contacts { get; set; }
}
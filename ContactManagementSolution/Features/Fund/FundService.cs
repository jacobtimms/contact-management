namespace ContactManagementSolution.Features.Fund;

using Entities;
using Microsoft.EntityFrameworkCore;

public class FundService(IFundDbContext context) : IFundService
{
    public async Task<bool> FundExistsAsync(Guid id, CancellationToken ct = default)
    {
        return await context.Funds.AnyAsync(x => x.Id == id, cancellationToken: ct);
    }
    
    public async Task<bool> ContactExistsAsync(Guid id, CancellationToken ct = default)
    {
        return await context.Contacts.AnyAsync(x => x.Id == id, cancellationToken: ct);
    }
    
    public async Task<bool> FundContactExistsAsync(Guid fundId, Guid contactId, CancellationToken ct = default)
    {
        return await context.FundContacts.AnyAsync(x => x.FundId == fundId && x.ContactId == contactId, cancellationToken: ct);
    }
    
    public async Task<IEnumerable<Fund>> GetAllFundsAsync(CancellationToken ct = default)
    {
        return await context.Funds.ToListAsync(cancellationToken: ct);
    }
    
    public async Task<FundContact?> GetFundContactAsync(Guid fundId, Guid contactId, CancellationToken ct = default)
    {
        return await context.FundContacts.FirstOrDefaultAsync(x => x.FundId == fundId && x.ContactId == contactId, cancellationToken: ct);
    }
    
    public async Task<IEnumerable<Contact>> ListFundContactsAsync(Guid id, CancellationToken ct = default)
    {
        return await context.FundContacts
            .Where(x => x.FundId == id)
            .Select(x => x.Contact)
            .ToListAsync(cancellationToken: ct);
    }
    
    public async Task AddFundContactAsync(Guid fundId, Guid contactId, CancellationToken ct = default)
    {
        var fundContact = new FundContact{ FundId = fundId, ContactId = contactId };
        await context.CreateEntityAsync(fundContact, ct);
    }
    
    public async Task RemoveFundContactAsync(FundContact fundContact, CancellationToken ct = default)
    {
        await context.DeleteEntityAsync(fundContact, ct);
    }
}

#region Interfaces

public interface IFundDbContext
{
    DbSet<Fund> Funds { get; set; }
    DbSet<Contact> Contacts { get; set; }
    DbSet<FundContact> FundContacts { get; set; }
    
    Task<TEntity> CreateEntityAsync<TEntity>(TEntity entity, CancellationToken ct = default) where TEntity : class;
    Task DeleteEntityAsync<TEntity>(TEntity entity, CancellationToken ct = default) where TEntity : class;
}

public interface IFundService
{
    Task<bool> FundExistsAsync(Guid id, CancellationToken ct = default);
    Task<bool> ContactExistsAsync(Guid id, CancellationToken ct = default);
    Task<bool> FundContactExistsAsync(Guid fundId, Guid contactId, CancellationToken ct = default);
    Task<IEnumerable<Fund>> GetAllFundsAsync(CancellationToken ct = default);
    Task<FundContact?> GetFundContactAsync(Guid fundId, Guid contactId, CancellationToken ct = default);
    Task<IEnumerable<Contact>> ListFundContactsAsync(Guid id, CancellationToken ct = default);
    Task AddFundContactAsync(Guid fundId, Guid contactId, CancellationToken ct = default);
    Task RemoveFundContactAsync(FundContact fundContact, CancellationToken ct = default);
}

#endregion Interfaces
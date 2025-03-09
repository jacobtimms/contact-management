namespace ContactManagementSolution.Features.Contact;

using Entities;
using Microsoft.EntityFrameworkCore;

public class ContactService(IContactDbContext context)
{
    public async Task<IEnumerable<Contact>> GetAllContactsAsync(CancellationToken ct = default)
    {
        return await context.Contacts.ToListAsync(cancellationToken: ct);
    }
    
    public async Task<Contact?> GetContactByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await context.Contacts.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: ct);
    }
    
    public async Task<Contact> CreateContactAsync(Contact contact, CancellationToken ct = default)
    {
        return await context.CreateEntityAsync(contact, ct);
    }
    
    public async Task UpdateContactAsync(Contact contact, CancellationToken ct = default)
    {
        await context.UpdateEntityAsync(contact, ct);
    }
    
    public async Task DeleteContactAsync(Contact contact, CancellationToken ct = default)
    {
        await context.DeleteEntityAsync(contact, ct);
    }
}

public interface IContactDbContext
{
    DbSet<Contact> Contacts { get; set; }
    Task<TEntity> CreateEntityAsync<TEntity>(TEntity entity, CancellationToken ct = default) where TEntity : class;
    Task UpdateEntityAsync<TEntity>(TEntity entity, CancellationToken ct = default) where TEntity : class;
    Task DeleteEntityAsync<TEntity>(TEntity entity, CancellationToken ct = default) where TEntity : class;
}
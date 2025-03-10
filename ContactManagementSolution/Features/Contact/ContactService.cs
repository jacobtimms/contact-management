﻿namespace ContactManagementSolution.Features.Contact;

using Entities;
using Microsoft.EntityFrameworkCore;

public class ContactService(IContactDbContext context) : IContactService
{
    public async Task<IEnumerable<Contact>> GetAllContactsAsync(CancellationToken ct = default)
    {
        return await context.Contacts.ToListAsync(cancellationToken: ct);
    }
    
    public async Task<Contact?> GetContactByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await context.Contacts.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: ct);
    }
    
    public async Task<bool> ContactAssignedToAnyFund(Guid id, CancellationToken ct = default)
    {
        return await context.FundContacts.AnyAsync(x => x.ContactId == id, cancellationToken: ct);
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

#region Interfaces

public interface IContactDbContext
{
    DbSet<Contact> Contacts { get; set; }
    DbSet<FundContact> FundContacts { get; set; }
    
    Task<TEntity> CreateEntityAsync<TEntity>(TEntity entity, CancellationToken ct = default) where TEntity : class;
    Task UpdateEntityAsync<TEntity>(TEntity entity, CancellationToken ct = default) where TEntity : class;
    Task DeleteEntityAsync<TEntity>(TEntity entity, CancellationToken ct = default) where TEntity : class;
}

public interface IContactService
{
    Task<IEnumerable<Contact>> GetAllContactsAsync(CancellationToken ct = default);
    Task<Contact?> GetContactByIdAsync(Guid id, CancellationToken ct = default);
    Task<bool> ContactAssignedToAnyFund(Guid id, CancellationToken ct = default);
    Task<Contact> CreateContactAsync(Contact contact, CancellationToken ct = default);
    Task UpdateContactAsync(Contact contact, CancellationToken ct = default);
    Task DeleteContactAsync(Contact contact, CancellationToken ct = default);
}

#endregion Interfaces
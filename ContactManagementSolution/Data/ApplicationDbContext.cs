namespace ContactManagementSolution.Data;

using Entities;
using Features.Contact;
using Features.Fund;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : DbContext(options), IFundDbContext, IContactDbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Fund> Funds { get; set; }
    public DbSet<FundContact> FundContacts { get; set; }
    
    public async Task<TEntity> CreateEntityAsync<TEntity>(TEntity entity, CancellationToken ct = default) where TEntity : class
    {
        var entry = await Set<TEntity>().AddAsync(entity, ct);
        await SaveChangesAsync(ct);

        return entry.Entity;
    }
    
    public async Task UpdateEntityAsync<TEntity>(TEntity entity, CancellationToken ct = default) where TEntity : class
    {
        Set<TEntity>().Update(entity);
        await SaveChangesAsync(ct);
    }
    
    public async Task DeleteEntityAsync<TEntity>(TEntity entity, CancellationToken ct = default) where TEntity : class
    {
        Set<TEntity>().Remove(entity);
        await SaveChangesAsync(ct);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FundContact>()
            .HasKey(fc => new { fc.FundId, fc.ContactId });

        modelBuilder.Entity<FundContact>()
            .HasOne(fc => fc.Fund)
            .WithMany(f => f.FundContacts)
            .HasForeignKey(fc => fc.FundId);

        modelBuilder.Entity<FundContact>()
            .HasOne(fc => fc.Contact)
            .WithMany(c => c.FundContacts)
            .HasForeignKey(fc => fc.ContactId);
    }
}
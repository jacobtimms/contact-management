namespace ContactManagementSolution.Data;

using Entities;
using Features.Fund;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : DbContext(options), IFundDbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Fund> Funds { get; set; }
    public DbSet<FundContact> FundContacts { get; set; }

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
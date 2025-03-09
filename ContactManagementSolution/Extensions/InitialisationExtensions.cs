namespace ContactManagementSolution.Extensions;

using Data;
using Entities;

public static class InitialisationExtensions
{
    /*public static void SeedDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.EnsureCreated();
            
        if (!dbContext.Contacts.Any())
        {
            dbContext.Contacts.AddRange(
                new Contact { Id = Guid.NewGuid(), Name = "John Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890" },
                new Contact { Id = Guid.NewGuid(), Name = "Jane Smith", Email = "jane.smith@example.com", PhoneNumber = "098-765-4321" }
            );
        }

        if (!dbContext.Funds.Any())
        {
            dbContext.Funds.AddRange(
                new Fund { Id = Guid.NewGuid(), Name = "Fund A" },
                new Fund { Id = Guid.NewGuid(), Name = "Fund B" },
                new Fund { Id = Guid.NewGuid(), Name = "Fund C" },
                new Fund { Id = Guid.NewGuid(), Name = "Fund D" },
                new Fund { Id = Guid.NewGuid(), Name = "Fund E" }
            );
        }

        dbContext.SaveChanges();
    }*/
    
    public static void SeedDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.EnsureCreated();

        if (!dbContext.Contacts.Any())
        {
            dbContext.Contacts.AddRange(TestData.Contacts);
            dbContext.SaveChanges();
        }

        if (!dbContext.Funds.Any())
        {
            dbContext.Funds.AddRange(TestData.Funds);
            dbContext.SaveChanges();
        }

        if (!dbContext.FundContacts.Any())
        {
            var contact1 = dbContext.Contacts.FirstOrDefault(c => c.Name == "John Doe");
            var contact2 = dbContext.Contacts.FirstOrDefault(c => c.Name == "Jane Smith");
            var fund1 = dbContext.Funds.FirstOrDefault(f => f.Name == "Fund A");
            var fund2 = dbContext.Funds.FirstOrDefault(f => f.Name == "Fund B");

            if (contact1 != null && contact2 != null && fund1 != null && fund2 != null)
            {
                dbContext.FundContacts.AddRange(
                    new FundContact { FundId = fund1.Id, ContactId = contact1.Id },
                    new FundContact { FundId = fund1.Id, ContactId = contact2.Id },
                    new FundContact { FundId = fund2.Id, ContactId = contact1.Id }
                );
                dbContext.SaveChanges();
            }
        }
    }
}

public static class TestData
{
    public static List<Contact> Contacts =>
    [
        new() { Id = Guid.NewGuid(), Name = "John Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890" },
        new() { Id = Guid.NewGuid(), Name = "Jane Smith", Email = "jane.smith@example.com", PhoneNumber = "098-765-4321" }
    ];

    public static List<Fund> Funds =>
    [
        new() { Id = Guid.NewGuid(), Name = "Fund A" },
        new() { Id = Guid.NewGuid(), Name = "Fund B" },
        new() { Id = Guid.NewGuid(), Name = "Fund C" },
        new() { Id = Guid.NewGuid(), Name = "Fund D" },
        new() { Id = Guid.NewGuid(), Name = "Fund E" }
    ];
}

namespace ContactManagementSolution.Extensions;

using Data;
using Entities;

public static class InitialisationExtensions
{
    public static void SeedDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.EnsureCreated();

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
    }
}
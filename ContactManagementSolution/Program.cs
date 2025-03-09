using ContactManagementSolution.Data;
using ContactManagementSolution.Extensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFastEndpoints();
builder.Services.AddDependencies();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.SeedDatabase();
app.UseHttpsRedirection();
app.UseFastEndpoints(c =>
{
    c.Versioning.Prefix = "v";
    c.Versioning.PrependToRoute = true;
    c.Serializer.Options.PropertyNamingPolicy = null;
    c.Endpoints.Configurator = ep =>
    {
        ep.AllowAnonymous();
    };
});

app.MapGet("/fundTest", async (ApplicationDbContext dbContext) =>
    {
        var funds = await dbContext.Funds.ToListAsync();
        return Results.Ok(funds);
    })
    .WithName("GetFunds")
    .WithOpenApi();

app.Run();

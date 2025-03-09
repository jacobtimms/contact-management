using ContactManagementSolution.Extensions;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSystemWebAdapters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFastEndpoints();
builder.Services.AddDependencies();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.SeedDatabase();
app.UseHttpsRedirection();
app.UseSystemWebAdapters();
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

app.Run();
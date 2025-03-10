using ContactManagementSolution.Extensions;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.RegisterDependencies();

var app = builder.Build();

app.SeedDatabase();
app.UseHttpsRedirection();
app.UseDefaultExceptionHandler(useGenericReason: true);
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
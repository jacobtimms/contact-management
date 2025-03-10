﻿
namespace ContactManagementSolution.Extensions;

using Data;
using Features.Contact;
using Features.Fund;
using Microsoft.EntityFrameworkCore;

public static class DependencyInjectionExtensions
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("Main"));
        
        services.AddDbContext<IFundDbContext, ApplicationDbContext>();
        services.AddDbContext<IContactDbContext, ApplicationDbContext>();
        
        services.AddScoped<IFundService, FundService>();
        services.AddScoped<IContactService, ContactService>();
    }
    
    private static void AddDbContext<TInterface, TImplementation>(this IServiceCollection services)
        where TInterface : class
        where TImplementation : class, TInterface
    {
        services.AddScoped<TInterface>(provider => provider.GetService<TImplementation>()!);
    }
}
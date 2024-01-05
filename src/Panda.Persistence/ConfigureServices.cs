using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Panda.Core.Common.Abstractions.Repositories;
using Panda.Core.Modules.Employees;
using Panda.Persistence.Repositories;

namespace Panda.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }

    public static async Task<IServiceCollection> ApplyMigrations(this IServiceCollection services)
    {
        using IServiceScope scope = services.BuildServiceProvider().CreateScope();
        ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await dbContext.Database.MigrateAsync();
        return services;
    }
}
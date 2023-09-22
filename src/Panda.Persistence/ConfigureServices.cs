using Microsoft.EntityFrameworkCore;
using Panda.Core.Common.Abstractions.Repositories;
using Panda.Core.Modules.Employees;
using Panda.Persistence;
using Panda.Persistence.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDBContext>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }

    public static async Task<IServiceCollection> ApplyMigrations(this IServiceCollection services)
    {
        using IServiceScope? scope = services.BuildServiceProvider().CreateScope();
        ApplicationDBContext? dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
        await dbContext.Database.MigrateAsync();
        return services;
    }

}
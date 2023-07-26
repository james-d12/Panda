using FluentValidation;
using MediatR;
using Panda.Core.Common.Behaviour;
using Panda.Core.Modules.Employees.UseCases;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidationServices();
        return services;
    }

    public static IServiceCollection AddValidationServices(this IServiceCollection services)
    {
        services.AddScoped<IValidator, CreateEmployeeCommandValidator>();
        services.AddScoped<IValidator, UpdateEmployeeCommandValidator>();
        return services;
    }
}
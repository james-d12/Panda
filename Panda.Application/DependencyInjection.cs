using Microsoft.Extensions.DependencyInjection;
using Panda.Application.Services.Authentication;

namespace Panda.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
 
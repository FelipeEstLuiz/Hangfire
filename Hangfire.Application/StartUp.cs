using Microsoft.Extensions.DependencyInjection;

namespace Hangfire.Application
{
    public static class StartUp

    {
        public static IServiceCollection ConfigureStart(
            this IServiceCollection services
        )
        {
            services.AddScoped<IServiceManagement, ServiceManagement>();

            return services;
        }
    }
}

using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Hangfire.Application
{
    public static class HangfireExtensions
    {
        public static IServiceCollection ConfigureHangfire(
            this IServiceCollection services,
            IWebHostEnvironment hostingEnvironment,
            IConfiguration configuration
        )
        {
            if (hostingEnvironment == null) throw new ArgumentNullException(nameof(hostingEnvironment));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            if (hostingEnvironment.IsDevelopment())
            {
                return ConfigureForDevelopment(services);
            }

            return ConfigureForProduction(services, configuration);
        }

        public static IServiceCollection ConfigureHangfire(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            return ConfigureForDevelopment(services);
        }

        private static IServiceCollection ConfigureForDevelopment(IServiceCollection services)
        {
            services.AddHangfire(op =>
            {
                op.UseMemoryStorage();
            });

            services.AddHangfireServer();

            return services;
        }

        private static IServiceCollection ConfigureForProduction(
            IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddHangfire(op =>
            {
                op.UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection"));

            });

            services.AddHangfireServer();

            return services;
        }
    }
}

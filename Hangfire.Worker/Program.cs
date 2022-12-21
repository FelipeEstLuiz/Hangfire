using Hangfire.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hangfire.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(builder =>
                {
                    builder.Configure(app =>
                    {
                        app.UseRouting();

                        app.UseHangfireDashboard();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapHangfireDashboard();
                        });
                    });
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.ConfigureStart();

                    services.ConfigureHangfire(hostContext.Configuration);

                    services.AddHostedService<Worker>();
                });
    }
}

using AutoMigrationsCodeFirst.Infarstructure;
using AutoMigrationsCodeFirst.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AutoMigrationsCodeFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // get configurations
            var configuration = GetConfiguration();

            // get builded host
            var host = BuildWebHost(configuration, args);

            // run migrations using extension method
            host.MigrateDbContext<TestDatabaseContext>((context, services) =>
            {
            });

            host.Run();
        }

        // get config settings and values
        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            var config = builder.Build();
            return builder.Build();
        }

        // get web host and build
        private static IWebHost BuildWebHost(IConfiguration configuration, string[] args) =>
              WebHost.CreateDefaultBuilder(args)
                  .CaptureStartupErrors(false)
                  .UseStartup<Startup>()
                 .UseContentRoot(Directory.GetCurrentDirectory())
                  .UseConfiguration(configuration)
                 .Build();

    }

}

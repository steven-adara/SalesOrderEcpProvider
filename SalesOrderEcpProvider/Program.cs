using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Kfzteile24.SalesOrderEcpProvider
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseHealthChecks("/hc")
            .UseStartup<Startup>()
            .ConfigureAppConfiguration((builderContext, configBuilder) => { configBuilder.AddEnvironmentVariables(); })
            .ConfigureLogging((builderContext, logging) =>
            {
                logging.AddConfiguration(builderContext.Configuration.GetSection("Logging"));
                logging.AddConsole();
                logging.AddDebug();
            })
            .Build();
    }
}

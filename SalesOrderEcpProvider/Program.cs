using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;


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
            .Build();
    }
}

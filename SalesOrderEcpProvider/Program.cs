﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
            .Build();
    }
}

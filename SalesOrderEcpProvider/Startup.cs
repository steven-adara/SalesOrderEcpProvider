using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Kfzteile24.SalesOrderEcpProvider.Helper;
using Kfzteile24.SalesOrderEcpProvider.Types;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.HealthChecks;

namespace Kfzteile24.SalesOrderEcpProvider
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks(checks =>
            {
                //checks.AddUrlCheck(Environment.GetEnvironmentVariable("SOP_API_URL"));
                checks.AddUrlCheck("http://localhost:50419/api/import");
                //checks.AddUrlCheck("https://github.com");
                // to be extended with cutomized healthchecks here
            });

            services.AddMvc();

            var serviceProvider = new AutofacServiceProvider(BuildServiceContainer(services));

            return serviceProvider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private IContainer BuildServiceContainer(IServiceCollection serviceDescriptors)
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<OrderMapper>().As<IMapper>();

            cb.Populate(serviceDescriptors);
            return cb.Build();
        }
    }
}

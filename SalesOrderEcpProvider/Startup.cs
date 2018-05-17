using System;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Kfzteile24.SalesOrderEcpProvider.Helper;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.HealthChecks;
using Prometheus;
using Swashbuckle.AspNetCore.Swagger;

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
            services.AddSingleton<DefaultSelfCheck>();

            services.AddHealthChecks(checks =>
            {
                checks.AddCheck<DefaultSelfCheck>("Self", TimeSpan.Zero);
                // to be extended with cutomized healthchecks here
            });

            services.AddMvc();

            services.AddSwaggerGen(sw =>
            {
                sw.SwaggerDoc("v2", new Info { Title = "Sales order provider for ECP shop", Version = "v1" } );
            });

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

            app.UseMetricServer();
            app.UseSwagger();
            app.UseSwaggerUI(sw =>
            {
                sw.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V1");
            });

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

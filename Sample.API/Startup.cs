using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sample.Domain.Abstract.Repositories;
using Sample.Infrastructure.Repositories;
using SimpleInjector;

namespace Sample.API
{
    public class Startup
    {
        private Container container = new SimpleInjector.Container();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            container.Options.ResolveUnregisteredConcreteTypes = false;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddSimpleInjector(container, options =>
            {

                options.AddAspNetCore()
                 .AddControllerActivation();
            });

            InitializeContainer();
        }

        private void InitializeContainer()
        {
            container.Register<IHelloWorldRepository, HelloWorldDAL>(Lifestyle.Singleton);
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSimpleInjector(container);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(
                builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();

                });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            container.Verify();
        }
    }
}

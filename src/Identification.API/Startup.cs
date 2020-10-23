using System.Reflection;
using Hlopov.CreditBroker.Identification.Application.Handlers;
using Hlopov.CreditBroker.Identification.Core.Configuration;
using Hlopov.CreditBroker.Identification.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hlopov.CreditBroker.Identification.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // configure core layer
            services.Configure<IdentificationOptions>(Configuration.GetSection(IdentificationOptions.Section));

            // configure infrastructure layer
            ConfigureDatabases(services);

            // configure application level
            services.AddMediatR(typeof(IdentificationHandler).GetTypeInfo().Assembly);

            // Configure API layer
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureDatabases(IServiceCollection services)
        {
            // use in-memory database
            // services.AddDbContext<FinflowContext>(c =>
            //    c.UseInMemoryDatabase("FinflowConnection"));

            // use real database
            services.AddDbContext<IdentityContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
        }
    }
}
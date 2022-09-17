namespace Api.GNB
{
    using Api.GNB.Module.Swagger;
    using Data.GNB.Seeder;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Reflection;
    using Utilities.Exception;
    using Utilities.Module;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name ?? throw new ArgumentException(nameof(migrationAssembly));
            services.AddControllers();

            services.AddUtilitiesService(Configuration);
            services.AddHttpClientService(Configuration);
            services.AddDataService(Configuration, migrationAssembly);
            services.AddGNBService(Configuration);
            services.AddGNBSwagger();
            services.AddVersioning();

        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IDbGenerate dbGenerate,
            IApiVersionDescriptionProvider provider
            )
        {
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                dbGenerate.Generate().GetAwaiter().GetResult();
            }
            app.UseVersionedSwagger(provider, this.Configuration, env);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

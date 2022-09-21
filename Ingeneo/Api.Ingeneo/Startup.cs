namespace Api.GNB
{
    using Api.GNB.Module.Swagger;
    using Api.Ingeneo;
    using Data.Ingenio.Seeder;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Reflection;
    using System.Text;
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

            var jwtTokenConfig = Configuration.GetSection("jwtTokenConfig").Get<JwtTokenConfig>();
            services.AddSingleton(jwtTokenConfig);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });

            services.AddUtilitiesService(Configuration);
            services.AddHttpClientService(Configuration);
            services.AddDataService(Configuration, migrationAssembly);
            services.AddIngenoService(Configuration);
            services.AddGNBSwagger();
            services.AddVersioning();
            services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
            services.AddHostedService<JwtRefreshTokenCache>();

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

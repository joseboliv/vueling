namespace Utilities.Module
{
    using Data.GNB.Context;
    using Data.GNB.Repositories;
    using Data.GNB.Seeder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DataModule
    {
        public static IServiceCollection AddDataService(this IServiceCollection services, IConfiguration configuration, string migrationAssembly)
        {
            string connectionString = configuration.GetValue<string>("ConnectionStrings:sqlServer");

            services.AddDbContext<GNBDbContext>(opt =>
                   opt.UseSqlServer(
                       connectionString,
                       optionSqlServer => optionSqlServer.MigrationsAssembly(migrationAssembly)
               ));
            services.AddScoped<IDbGenerate, DbGenerate>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRateRepository, RateRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            return services;
        }
    }
}

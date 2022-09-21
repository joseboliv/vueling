namespace Utilities.Module
{
    using Data.Ingenio.Context;
    using Data.Ingenio.Repositories;
    using Data.Ingenio.Seeder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DataModule
    {
        public static IServiceCollection AddDataService(this IServiceCollection services, IConfiguration configuration, string migrationAssembly)
        {
            string connectionString = configuration.GetValue<string>("ConnectionStrings:sqlServer");

            services.AddDbContext<IngenioDbContext>(opt =>
                   opt.UseSqlServer(
                       connectionString,
                       optionSqlServer => optionSqlServer.MigrationsAssembly(migrationAssembly)
               ));
            services.AddScoped<IDbGenerate, DbGenerate>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}

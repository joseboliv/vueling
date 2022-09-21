namespace Utilities.Module
{
    using Core.Ingenio.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class CoreModule
    {
        public static IServiceCollection AddIngenoService(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddTransient<IUserServices, UserServices>()
                .AddTransient<IAuthorServices, AuthorServices>()
                .AddTransient<IBookServices, BookServices>();
    }
}

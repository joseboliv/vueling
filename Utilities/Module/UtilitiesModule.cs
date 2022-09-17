namespace Utilities.Module
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Utilities.Logger;

    public static class UtilitiesModule
    {
        public static IServiceCollection AddUtilitiesService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(ILoggerGNB<>), typeof(LoggerGNB<>));
            return services;
        }
    }
}

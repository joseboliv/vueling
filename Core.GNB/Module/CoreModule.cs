namespace Utilities.Module
{
    using Core.GNB.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class CoreModule
    {
        public static IServiceCollection AddGNBService(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddTransient<IRateServices, RateServices>()
                .AddTransient<ITransactionServices, TransactionServices>();
    }
}

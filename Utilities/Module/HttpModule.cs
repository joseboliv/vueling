namespace Utilities.Module
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Utilities.Http;

    public static class HttpModule
    {
        public static IServiceCollection AddHttpClientService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<HttpClient>();
            services.AddTransient<IHttpClientServices, HttpClientServices>();

            services.AddHttpClient("Vueling", client =>
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(configuration["Services:Vueling:url"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(configuration["Services:Vueling:Application"]));
                client.DefaultRequestHeaders.Add(configuration["Services:Vueling:Cache"], configuration["Services:Vueling:NoChace"]);
            });
            return services;
        }
    }
}

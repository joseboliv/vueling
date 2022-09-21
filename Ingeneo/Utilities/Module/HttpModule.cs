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

            services.AddHttpClient("faker", client =>
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(configuration["Services:faker:url"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(configuration["Services:faker:Application"]));
                client.DefaultRequestHeaders.Add(configuration["Services:faker:Cache"], configuration["Services:faker:NoChace"]);
            });
            return services;
        }
    }
}

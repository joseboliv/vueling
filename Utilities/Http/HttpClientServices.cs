namespace Utilities.Http
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Utilities.Logger;

    internal class HttpClientServices : IHttpClientServices
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILoggerGNB<HttpClientServices> logger;

        public HttpClientServices(
            IHttpClientFactory httpClientFactory,
            ILoggerGNB<HttpClientServices> logger)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Response> GetUnAuthAsync<Response>(string pathUrl)
        {
            logger.LogInformation(nameof(GetUnAuthAsync));
            var cliente = httpClientFactory.CreateClient("Vueling");
            HttpResponseMessage response = await cliente.GetAsync(pathUrl);
            logger.LogInformation($"{response.IsSuccessStatusCode}");
            if (!response.IsSuccessStatusCode)
            {
                logger.LogError($"Exception: {response.IsSuccessStatusCode}");
                return default(Response);
            }
            var contenido = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(contenido);
        }
    }
}

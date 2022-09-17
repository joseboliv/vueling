namespace Web.Core.GNB.Business
{
    using Domain.GNB.Dto;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Utilities.Http;

    public class RatesServices : IRatesServices
    {
        private readonly IHttpClientServices httpServices;

        public RatesServices(IHttpClientServices httpServices)
        {
            this.httpServices = httpServices ?? throw new ArgumentNullException(nameof(IHttpClientServices));
        }

        public async Task<IEnumerable<RatesDto>> GetRateAsync() => 
            await httpServices.GetUnAuthAsync<IEnumerable<RatesDto>>("/api/v1/Rate");
    }
}
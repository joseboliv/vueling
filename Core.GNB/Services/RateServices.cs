namespace Core.GNB.Services
{
    using Core.GNB.Constans;
    using Data.GNB.Repositories;
    using Domain.GNB.Dto;
    using Domain.GNB.Entity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Utilities.Http;
    using Utilities.Logger;

    public class RateServices : IRateServices
    {
        private readonly IHttpClientServices services;
        private readonly IRateRepository repository;
        private readonly ILoggerGNB<RateServices> logger;

        public RateServices(
            IHttpClientServices services,
            IRateRepository repository,
            ILoggerGNB<RateServices> logger
            )
        {
            this.services = services ?? throw new ArgumentNullException(nameof(IHttpClientServices));
            this.repository = repository ?? throw new ArgumentNullException(nameof(IRateRepository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(ILoggerGNB<RateServices>));
        }

        public async Task<IEnumerable<RatesDto>> GetRatesAsync()
        {
            DateTime startTime = DateTime.Now;
            logger.LogInformation($"Method: {nameof(GetRatesAsync)} start: {startTime}");
            var result = await GetRatesFromRestOrDbAsync();
            return result;
        }

        private async Task<IEnumerable<RatesDto>> GetRatesFromRestOrDbAsync()
        {
            DateTime startTime = DateTime.Now;
            logger.LogInformation($"Method: {nameof(GetRatesFromRestOrDbAsync)} start: {startTime}");
            var result = await services.GetUnAuthAsync<IEnumerable<RatesDto>>(UrlConstans.Rates);
            if (result != null)
            {
                await repository.RemovePhysicalAllElementsAsync();
                await repository.AddRangeAsync(result.Select(m => (RateEntity)m));
            }
            else
            {
                result = GetRatesFromDb();
            }
            logger.LogInformation($"Method: {nameof(GetRatesFromRestOrDbAsync)} end: {((DateTime.Now - startTime)).TotalMilliseconds}");
            return result;
        }

        public IEnumerable<RatesDto> GetRatesFromDb()
        {
            DateTime startTime = DateTime.Now;
            logger.LogInformation($"Method: {nameof(GetRatesFromDb)} start: {startTime}");
            var result = repository.Find().ToList();
            if (!result.Any())
            {
                result = repository.Find().ToList();
            }
            logger.LogInformation($"Method: {nameof(GetRatesFromDb)} end: {((DateTime.Now - startTime)).TotalMilliseconds}");
            return result.Select(m => (RatesDto)m).ToList();
        }
    }
}

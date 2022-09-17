namespace Core.GNB.Services
{
    using Core.GNB.Constans;
    using Data.GNB.Repositories;
    using Domain.GNB.Dto;
    using Domain.GNB.Entity;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Utilities.Http;
    using Utilities.Logger;

    public class TransactionServices : ITransactionServices
    {
        private readonly IHttpClientServices services;
        private readonly IRateServices rateServices;
        private readonly ITransactionRepository repository;
        string DefaultCurrency = string.Empty;
        private readonly ILoggerGNB<TransactionServices> logger;
        List<RatesDto> listRates = new();

        public TransactionServices(
            IHttpClientServices services,
            ITransactionRepository repository,
            IConfiguration configuration,
            IRateServices rateServices,
            ILoggerGNB<TransactionServices> logger
            )
        {
            this.rateServices = rateServices ?? throw new ArgumentNullException(nameof(IRateServices));
            this.services = services ?? throw new ArgumentNullException(nameof(IHttpClientServices));
            this.repository = repository ?? throw new ArgumentNullException(nameof(ITransactionRepository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(ILoggerGNB<TransactionServices>));
            DefaultCurrency = configuration.GetValue<string>("DefaultCurrency");
        }

        public async Task<ResponseDto> GetTransactionAsync()
        {
            DateTime startTime = DateTime.Now;
            logger.LogInformation($"Method: {nameof(GetTransactionAsync)} start: {startTime}");
            IEnumerable<TransactionsDto> result = await GetTransactionsFromRestOrDbAsync();
            return new ResponseDto(result, ((DateTime.Now - startTime)).TotalMilliseconds);
        }

        public async Task<ResponseDto> GetTransactionBySkuAsync(string sku)
        {
            DateTime startTime = DateTime.Now;
            logger.LogInformation($"Method: {nameof(GetTransactionBySkuAsync)} start: {startTime}");
            var transactions = await GetTransactionFromDbBySkuAsync(sku);
            List<TransactionsDto> listTransaction = new();
            listRates = (await rateServices.GetRatesAsync()).ToList();

            foreach (var item in transactions)
            {
                listTransaction.Add(new TransactionsDto(item.Sku, DefaultCurrency, CurrencyConverter(item.Currency, DefaultCurrency, item.Amount, listRates)));
            }
            logger.LogInformation($"Method: {nameof(GetTransactionBySkuAsync)} end: {((DateTime.Now - startTime)).TotalMilliseconds}");
            return new ResponseDto(listTransaction, listTransaction.Sum(m => m.Amount), listTransaction.Count, ((DateTime.Now - startTime)).TotalMilliseconds);
        }

        private async Task<IEnumerable<TransactionsDto>> GetTransactionsFromRestOrDbAsync()
        {
            DateTime startTime = DateTime.Now;
            logger.LogInformation($"Method: {nameof(GetTransactionsFromRestOrDbAsync)} start: {startTime}");
            var result = await services.GetUnAuthAsync<IEnumerable<TransactionsDto>>(UrlConstans.Transactions);
            if (result.Any())
            {
                await repository.RemovePhysicalAllElementsAsync();
                await repository.AddRangeAsync(result.Select(m => (TransactionEntity)m));
            }
            else
            {
                result = repository.Find().Select(m => (TransactionsDto)m).ToList();
            }
            logger.LogInformation($"Method: {nameof(GetTransactionsFromRestOrDbAsync)} end: {((DateTime.Now - startTime)).TotalMilliseconds}");
            return result;
        }

        private async Task<IEnumerable<TransactionsDto>> GetTransactionFromDbBySkuAsync(string sku)
        {
            DateTime startTime = DateTime.Now;
            logger.LogInformation($"Method: {nameof(GetTransactionFromDbBySkuAsync)} start: {startTime}");
            Expression<Func<TransactionEntity, bool>> expresion = s => s.Sku.Equals(sku);
            var query = repository.Find();
            if (!query.Any())
            {
                await GetTransactionsFromRestOrDbAsync();
            }
            logger.LogInformation($"Method: {nameof(GetTransactionFromDbBySkuAsync)} end: {((DateTime.Now - startTime)).TotalMilliseconds}");
            return query.Where(expresion).Select(m => (TransactionsDto)m).ToList();
        }


        private double CurrencyConverter(string currentCurrency, string expectedCurrency, double amountTransaction, List<RatesDto> currencies)
        {
            DateTime startTime = DateTime.Now;
            logger.LogInformation($"Method: {nameof(CurrencyConverter)} start: {startTime}, Currency: {currentCurrency} - Expected Currency: {expectedCurrency} - Amount = {amountTransaction}");

            if (currentCurrency == expectedCurrency)
                return amountTransaction;

            var findCurrency = currencies
                    .Where(m => m.From.Equals(currentCurrency) && m.To.Equals(expectedCurrency))
                    .FirstOrDefault();

            if (findCurrency != null)
                return amountTransaction *= findCurrency.Rate;

            bool complete = false;
            int position = 0;
            string afterCurrency = string.Empty;

            while (!complete)
            {
                var query = currencies.ElementAt(position);

                if (query.From == currentCurrency && afterCurrency != query.To)
                {
                    afterCurrency = query.From;
                    currentCurrency = query.To;
                    amountTransaction *= query.Rate;
                }

                findCurrency = currencies
                        .Where(m => m.From.Equals(currentCurrency) && m.To.Equals(expectedCurrency))
                        .FirstOrDefault();

                if (findCurrency != null)
                    return amountTransaction *= findCurrency.Rate;

                findCurrency = currencies
                        .Where(m => m.To.Equals(currentCurrency) && m.From.Equals(expectedCurrency))
                        .FirstOrDefault();

                if (findCurrency != null)
                    return amountTransaction /= findCurrency.Rate;

                position++;
                if (position == currencies.Count)
                {
                    position = 0;
                    afterCurrency = string.Empty;
                }
            }
            return amountTransaction;
        }
    }
}

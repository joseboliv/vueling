namespace Web.Core.GNB.Business
{
    using Domain.GNB.Dto;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Utilities.Http;

    public class TransactionsServices : ITransactionsServices
    {
        private readonly IHttpClientServices httpServices;

        public TransactionsServices(IHttpClientServices httpServices)
        {
            this.httpServices = httpServices;
        }

        public async Task<IEnumerable<TransactionsDto>> GetTransactionsAsync()
        {
            var result = await httpServices.GetUnAuthAsync<ReceiveDto>($"/api/v1/Transaction");
            return result.Result;
        }


        public async Task<IEnumerable<TransactionsDto>> GetTransactionsBySkuAsync(string sku)
        {
            var result = await httpServices.GetUnAuthAsync<ReceiveDto>($"/api/v1/Transaction/GetTransactionBySku?sku={sku}");
            return result.Result;
        }
    }
}
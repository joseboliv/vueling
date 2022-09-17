namespace Web.Core.GNB.Business
{
    using Domain.GNB.Dto;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITransactionsServices
    {
        Task<IEnumerable<TransactionsDto>> GetTransactionsAsync();
        Task<IEnumerable<TransactionsDto>> GetTransactionsBySkuAsync(string sku);
    }
}
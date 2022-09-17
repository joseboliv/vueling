namespace Core.GNB.Services
{
    using Domain.GNB.Dto;
    using System.Threading.Tasks;

    public interface ITransactionServices
    {
        Task<ResponseDto> GetTransactionBySkuAsync(string sku);
        Task<ResponseDto> GetTransactionAsync();
    }
}
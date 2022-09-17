namespace Core.GNB.Services
{
    using Domain.GNB.Dto;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRateServices
    {
        Task<IEnumerable<RatesDto>> GetRatesAsync();
    }
}
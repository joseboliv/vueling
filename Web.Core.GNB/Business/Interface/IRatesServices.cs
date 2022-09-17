namespace Web.Core.GNB.Business
{
    using Domain.GNB.Dto;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRatesServices
    {
        Task<IEnumerable<RatesDto>> GetRateAsync();
    }
}
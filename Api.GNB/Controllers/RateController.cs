namespace Api.GNB.Controllers
{
    using Core.GNB.Services;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [ApiVersion("1.0")]
    public class RateController : BaseController<RateController>
    {
        private readonly IRateServices services;

        public RateController(
            IRateServices services)
        {
            this.services = services ?? throw new ArgumentNullException(nameof(IRateServices));
        }

        [HttpGet]
        public async Task<IActionResult> GetRates()
        {
            var result = await services.GetRatesAsync();
            return Ok(result);
        }
    }
}

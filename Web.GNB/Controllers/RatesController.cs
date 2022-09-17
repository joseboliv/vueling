namespace Web.GNB.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using Utilities.Logger;
    using Web.Core.GNB.Business;

    public class RatesController : BaseController<RatesController>
    {
        private readonly IRatesServices rateService;

        public RatesController(
            ILoggerGNB<RatesController> logger,
            IRatesServices rateService
            ) : base(logger)
        {
            this.rateService = rateService ?? throw new ArgumentNullException(nameof(IRatesServices));
        }

        // GET: Rates
        public async Task<IActionResult> Index()
        {
            var tes = await rateService.GetRateAsync();
            return View(tes);
        }
    }
}
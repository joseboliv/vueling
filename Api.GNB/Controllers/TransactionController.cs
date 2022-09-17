namespace Api.GNB.Controllers
{
    using Core.GNB.Services;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [ApiVersion("1.0")]
    public class TransactionController : BaseController<TransactionController>
    {
        private readonly ITransactionServices services;

        public TransactionController(
            ITransactionServices services
            )
        {
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            var result = await services.GetTransactionAsync();
            return Ok(result);
        }

        [HttpGet("GetTransactionBySku")]
        public async Task<IActionResult> GetTransactionBySku([FromQuery] string sku)
        {
            if (string.IsNullOrEmpty(sku))
                throw new ArgumentNullException($"{sku} is required");

            var result = await services.GetTransactionBySkuAsync(sku);

            return Ok(result);
        }
    }
}

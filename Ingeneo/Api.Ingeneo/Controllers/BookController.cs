namespace Api.GNB.Controllers
{
    using Core.Ingenio.Services;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [ApiVersion("1.0")]
    public class BookController : BaseController<BookController>
    {
        private readonly IBookServices services;

        public BookController(
            IBookServices services
            )
        {
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            
            return Ok();
        }

        [HttpGet("GetTransactionBySku")]
        public async Task<IActionResult> GetTransactionBySku([FromQuery] string sku)
        {
            if (string.IsNullOrEmpty(sku))
                throw new ArgumentNullException($"{sku} is required");

            return Ok();
        }
    }
}

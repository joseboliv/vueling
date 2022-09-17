namespace Web.GNB.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using Utilities.Logger;
    using Web.Core.GNB.Business;

    public class TransactionsController : BaseController<TransactionsController>
    {
        private readonly ITransactionsServices transactionsServices;

        public TransactionsController(
            ILoggerGNB<TransactionsController> logger,
            ITransactionsServices transactionsServices
            ) : base(logger)
        {
            this.transactionsServices = transactionsServices;
        }

        // GET: Transactions
        public async Task<IActionResult> Index(string sku)
        {
            try
            {
                if (string.IsNullOrEmpty(sku))
                {
                    return View(await transactionsServices.GetTransactionsAsync());
                }
                else
                {
                    return View(await transactionsServices.GetTransactionsBySkuAsync(sku));
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
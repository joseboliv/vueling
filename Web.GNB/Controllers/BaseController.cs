namespace Web.GNB.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Utilities.Logger;

    public class BaseController<T> : Controller
    {
        protected readonly ILoggerGNB<T> _logger;

        public BaseController(ILoggerGNB<T> logger)
        {
            _logger = logger;
        }
    }
}
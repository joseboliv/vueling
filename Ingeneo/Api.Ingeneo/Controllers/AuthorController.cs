namespace Api.GNB.Controllers
{
    using Core.Ingenio.Services;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [ApiVersion("1.0")]
    public class AuthorController : BaseController<AuthorController>
    {
        private readonly IAuthorServices services;

        public AuthorController(
            IAuthorServices services)
        {
            this.services = services ?? throw new ArgumentNullException(nameof(IUserServices));
        }

        [HttpGet]
        public async Task<IActionResult> GetRates()
        {
            return Ok();
        }
    }
}

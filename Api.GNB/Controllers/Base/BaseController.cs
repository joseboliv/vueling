namespace Api.GNB.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    //[Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BaseController<T> : Controller
    {

        public BaseController()
        {

        }
    }
}

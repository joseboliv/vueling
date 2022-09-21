namespace Api.GNB.Controllers
{
    using Api.Ingeneo;
    using Core.Ingenio.Services;
    using Domain.Ingenio.Dto;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [ApiVersion("1.0")]
    public class UserController : BaseController<UserController>
    {
        private readonly IUserServices services;
        private readonly IJwtAuthManager jwtAuthManager;

        public UserController(
            IUserServices services,
            IJwtAuthManager jwtAuthManager)
        {
            this.jwtAuthManager = jwtAuthManager ?? throw new ArgumentNullException(nameof(IJwtAuthManager));
            this.services = services ?? throw new ArgumentNullException(nameof(IUserServices));
        }

        [HttpPost(nameof(LoginAsync))]
        public async Task<IActionResult> LoginAsync([FromBody] UserDto userDto)
        {

            var isValidUser = await services.GetUsersAsync(userDto.Username, userDto.Password);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, isValidUser.userName),
                new Claim(ClaimTypes.NameIdentifier, isValidUser.Id.ToString()),
            };

            var jwtResult = jwtAuthManager.GenerateTokens(isValidUser.userName, claims, DateTime.Now);

            return Ok(new ResponseLoginDto(isValidUser.Id, isValidUser.userName, jwtResult.AccessToken, jwtResult.RefreshToken.TokenString));
        }
    }
}

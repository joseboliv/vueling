namespace Core.Ingenio.Services
{
    using Domain.Ingenio.Dto;
    using Domain.Ingenio.Entity;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserServices
    {
        Task<User> GetUsersAsync(string user, string password);
    }
}
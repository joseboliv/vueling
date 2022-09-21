namespace Core.Ingenio.Services
{
    using Core.Ingenio.Constans;
    using Data.Ingenio.Repositories;
    using Domain.Ingenio.Dto;
    using Domain.Ingenio.Entity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Utilities.Http;
    using Utilities.Logger;

    public class UserServices : IUserServices
    {
        private readonly IHttpClientServices services;
        private readonly IUserRepository repository;
        private readonly ILoggerIngenio<UserServices> logger;

        public UserServices(
            IHttpClientServices services,
            IUserRepository repository,
            ILoggerIngenio<UserServices> logger
            )
        {
            this.services = services ?? throw new ArgumentNullException(nameof(IHttpClientServices));
            this.repository = repository ?? throw new ArgumentNullException(nameof(IBookRepository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(ILoggerIngenio<UserServices>));
        }

        public async Task<User> GetUsersAsync(string user, string password)
        {
            DateTime startTime = DateTime.Now;
            logger.LogInformation($"Method: {nameof(GetUsersAsync)} start: {startTime}");

            var users = await GetRatesFromRestOrDbAsync();
            var result = users.Where(m => m.userName.Equals(user) && m.password.Equals(password)).FirstOrDefault();

            if (result == null)
            {
                throw new ArgumentNullException();
            }
            return result;
        }

        private async Task<IEnumerable<User>> GetRatesFromRestOrDbAsync()
        {
            DateTime startTime = DateTime.Now;
            logger.LogInformation($"Method: {nameof(GetRatesFromRestOrDbAsync)} start: {startTime}");
            var result = await services.GetUnAuthAsync<IEnumerable<User>>(UrlConstans.User);
            logger.LogInformation($"Method: {nameof(GetRatesFromRestOrDbAsync)} end: {((DateTime.Now - startTime)).TotalMilliseconds}");
            return result;
        }


    }
}

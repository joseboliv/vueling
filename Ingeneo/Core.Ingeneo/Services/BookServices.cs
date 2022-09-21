namespace Core.Ingenio.Services
{
    using Core.Ingenio.Constans;
    using Data.Ingenio.Repositories;
    using Data.Ingenio.Repositories;
    using Domain.Ingenio.Dto;
    using Domain.Ingenio.Entity;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Utilities.Http;
    using Utilities.Logger;

    public class BookServices : IBookServices
    {
        private readonly IHttpClientServices services;
        private readonly IUserServices rateServices;
        private readonly IUserRepository repository;
        string DefaultCurrency = string.Empty;
        private readonly ILoggerIngenio<BookServices> logger;

        public BookServices(
            IHttpClientServices services,
            IUserRepository repository,
            IConfiguration configuration,
            IUserServices rateServices,
            ILoggerIngenio<BookServices> logger
            )
        {
            this.rateServices = rateServices ?? throw new ArgumentNullException(nameof(IUserServices));
            this.services = services ?? throw new ArgumentNullException(nameof(IHttpClientServices));
            this.repository = repository ?? throw new ArgumentNullException(nameof(IUserRepository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(ILoggerIngenio<BookServices>));
            DefaultCurrency = configuration.GetValue<string>("DefaultCurrency");
        }
        
    }
}

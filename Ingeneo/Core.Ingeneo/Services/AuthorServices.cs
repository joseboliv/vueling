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

    public class AuthorServices : IAuthorServices
    {
        private readonly IHttpClientServices services;
        private readonly IBookRepository repository;
        private readonly ILoggerIngenio<AuthorServices> logger;

        public AuthorServices(
            IHttpClientServices services,
            IBookRepository repository,
            ILoggerIngenio<AuthorServices> logger
            )
        {
            this.services = services ?? throw new ArgumentNullException(nameof(IHttpClientServices));
            this.repository = repository ?? throw new ArgumentNullException(nameof(IBookRepository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(ILoggerIngenio<AuthorServices>));
        }

        
    }
}

namespace Data.Ingenio.Repositories
{
    using Data.Ingenio.Context;
    using Domain.Ingenio.Entity;
    using Utilities.Logger;

    internal class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(
            IngenioDbContext context,
            ILoggerIngenio<Repository<Author>> logger
            ) : base(context, logger) { }
    }
}

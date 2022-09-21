namespace Data.Ingenio.Repositories
{
    using Data.Ingenio.Context;
    using Domain.Ingenio.Entity;
    using Utilities.Logger;

    internal class UserRepository : Repository<Book>, IUserRepository
    {
        public UserRepository(
            IngenioDbContext context,
            ILoggerIngenio<Repository<Book>> logger
            ) : base(context, logger) { }
    }
}

namespace Data.Ingenio.Repositories
{
    using Data.Ingenio.Context;
    using Domain.Ingenio.Entity;
    using Utilities.Logger;

    internal class BookRepository : Repository<Author>, IBookRepository
    {
        public BookRepository(
            IngenioDbContext context,
            ILoggerIngenio<Repository<Author>> logger
            ) : base(context, logger) { }
    }
}

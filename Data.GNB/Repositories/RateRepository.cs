namespace Data.GNB.Repositories
{
    using Data.GNB.Context;
    using Domain.GNB.Entity;
    using Utilities.Logger;

    internal class RateRepository : Repository<RateEntity>, IRateRepository
    {
        public RateRepository(
            GNBDbContext context,
            ILoggerGNB<Repository<RateEntity>> logger
            ) : base(context, logger) { }
    }
}

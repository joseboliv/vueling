namespace Data.GNB.Repositories
{
    using Data.GNB.Context;
    using Domain.GNB.Entity;
    using Utilities.Logger;

    internal class TransactionRepository : Repository<TransactionEntity>, ITransactionRepository
    {
        public TransactionRepository(
            GNBDbContext context,
            ILoggerGNB<Repository<TransactionEntity>> logger
            ) : base(context, logger) { }
    }
}

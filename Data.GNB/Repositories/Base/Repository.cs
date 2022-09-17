namespace Data.GNB.Repositories
{
    using Data.GNB.Context;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Utilities.Logger;

    internal class Repository<T> : IRepository<T> where T : class
    {
        internal readonly GNBDbContext context;
        protected readonly ILoggerGNB<Repository<T>> logger;
        internal readonly DbSet<T> dbSet;

        public Repository(
            GNBDbContext context,
            ILoggerGNB<Repository<T>> logger
            )
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            logger.LogInformation(nameof(AddRangeAsync));
            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();
            return entities;
        }

        public virtual async Task RemovePhysicalAllElementsAsync()
        {
            var entity = context.Set<T>();
            context.RemoveRange(entity.ToList());
            await Task.CompletedTask;
        }

        public async Task<IQueryable<T>> QueryableWithWhereConditionAsync(Expression<Func<T, bool>> predicate)
        {
            logger.LogInformation("Executed method: {0}", nameof(QueryableWithWhereConditionAsync));
            return await Task.FromResult(context.Set<T>().Where(predicate).AsQueryable());
        }

        public IQueryable<T> Find()
        {
            logger.LogInformation(nameof(Find));
            return context.Set<T>().AsQueryable();
        }
    }
}

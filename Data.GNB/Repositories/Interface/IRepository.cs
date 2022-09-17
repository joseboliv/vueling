namespace Data.GNB.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        IQueryable<T> Find();
        Task<IQueryable<T>> QueryableWithWhereConditionAsync(Expression<Func<T, bool>> predicate);
        Task RemovePhysicalAllElementsAsync();
    }
}

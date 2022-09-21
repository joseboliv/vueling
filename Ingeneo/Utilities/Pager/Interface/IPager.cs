namespace Utilities.Pager
{
    using System.Collections.Generic;

    public interface IPager<T>
    {
        IEnumerable<T> Items { get; set; }
        int PageSize { get; set; }
        int TotalCount { get; set; }
        int TotalPages { get; set; }
    }
}
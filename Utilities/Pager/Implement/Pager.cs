namespace Utilities.Pager
{
    using System.Collections.Generic;

    public class Pager<T> : IPager<T>
    {
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}

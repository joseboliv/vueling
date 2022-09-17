namespace Utilities.Pager.Implement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;

    public class PagerBuilder<Source, Result>
    {
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }
        public IEnumerable<Result> Items { get; private set; }

        private PagerBuilder(IQueryable<Source> source, int pageSize, int skip)
        {
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
            Items = ConvertSourceToResult(source, pageSize, skip);
        }

        private PagerBuilder(IQueryable<Source> source, int pageSize, int skip, int totalCount)
        {
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
            Items = ConvertSourceToResultWithOutPager(source);
        }

        public static IPager<Result> GetPager(IQueryable<Source> source, int pageSize, int skip)
        {
            var instance = new PagerBuilder<Source, Result>(source, pageSize, skip);
            return new Pager<Result>
            {
                PageSize = instance.PageSize,
                TotalCount = instance.TotalCount,
                TotalPages = instance.TotalPages,
                Items = instance.Items
            };
        }

        public static IPager<Result> GetPager(IQueryable<Source> source, int pageSize, int skip, int numberElements)
        {
            var instance = new PagerBuilder<Source, Result>(source, pageSize, skip, numberElements);
            return new Pager<Result>
            {
                PageSize = instance.PageSize,
                TotalCount = instance.TotalCount,
                TotalPages = instance.TotalPages,
                Items = instance.Items
            };
        }

        private IEnumerable<Result> ConvertSourceToResult(IQueryable<Source> source, int pageSize, int skip)
        {
            var jsonString = JsonSerializer.Serialize(source.Skip(skip).Take(pageSize).ToList(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return JsonSerializer.Deserialize<IEnumerable<Result>>(jsonString);
        }

        private IEnumerable<Result> ConvertSourceToResultWithOutPager(IQueryable<Source> source)
        {
            var jsonString = JsonSerializer.Serialize(source.ToList(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return JsonSerializer.Deserialize<IEnumerable<Result>>(jsonString);
        }
    }
}

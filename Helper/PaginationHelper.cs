using System;
using System.Collections.Generic;
using System.Linq;

namespace OrigamiEdu.Helper
{
    public class PaginationHelper<T> : List<T>
    {
        public int PageIndex { get; private set; }

        public int TotalPages { get; private set; }

        public PaginationHelper(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count/(double)pageSize);
            this.AddRange(items);
        }

        public bool HasPrevPage
        {
            get{
                return(PageIndex > 1);
            }
        }

        public bool HasNextPage{
            get{
                return(PageIndex < TotalPages);
            }
        }

        public static PaginationHelper<T> Create(IQueryable<T> source, int PageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((PageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new PaginationHelper<T>(items, count, PageIndex, pageSize);
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace CRM.Application.Infrastructure.Pagination
{
    public class PaginatedList<T>
    {
        public PaginatedList(int totalCount, IEnumerable<T> items)
        {
            TotalCount = totalCount;
            Items = items.ToList();
        }

        public int TotalCount { get; }

        public List<T> Items { get; }
    }
}
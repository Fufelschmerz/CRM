using Queries.Abstractions.Criterions;

namespace CRM.Application.Infrastructure.Queries.Defaults
{
    public class FindPaginationByFilter<T> : ICriterion
    {
        public FindPaginationByFilter(int offset, int count, T filter)
        {
            Offset = offset;
            Count = count;
            Filter = filter;
        }

        public int Offset { get; }

        public int Count { get; }

        public T Filter { get; }
    }
}

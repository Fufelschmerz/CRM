using Queries.Abstractions.Criterions;

namespace CRM.Application.Infrastructure.Queries.Entities.Contacts
{
    public class FindPaginationContactsByManagerId : ICriterion
    {
        public FindPaginationContactsByManagerId(int offset, int count, long managerId)
        {
            Offset = offset;
            Count = count;
            ManagerId = managerId;
        }

        public int Offset { get; }

        public int Count { get; }

        public long ManagerId { get; }
    }
}
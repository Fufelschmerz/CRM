using Queries.Abstractions.Criterions;

namespace CRM.Domain.Users.Criteria
{
    public class FindUserNotBannedById : ICriterion
    {
        public FindUserNotBannedById(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}
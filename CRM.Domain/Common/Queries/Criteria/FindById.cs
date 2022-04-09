namespace CRM.Domain.Common.Queries.Criteria
{
    using global :: Queries.Abstractions.Criterions;

    public class FindById : ICriterion
    {
        public long Id { get; }

        public FindById(long id)
        {
            Id = id;
        }
    }
}

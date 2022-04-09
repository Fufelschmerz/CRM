namespace CRM.Domain.Common.Queries.Criteria
{
    using global::Queries.Abstractions.Criterions;
    using System;

    public class FindByName : ICriterion
    {
        public string Name { get; protected set; }

        public FindByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name));

            Name = name;
        }
    }
}

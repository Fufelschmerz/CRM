using System;
using Queries.Abstractions.Criterions;

namespace CRM.Domain.Users.Criteria
{
    public class FindUserByEmail : ICriterion
    {
        public string Email { get; }

        public FindUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException(nameof(email));

            Email = email;
        }
    }
}

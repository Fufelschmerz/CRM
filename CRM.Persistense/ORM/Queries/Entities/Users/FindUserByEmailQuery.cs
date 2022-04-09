using System.Threading;
using System.Threading.Tasks;
using CRM.Domain.Users.Criteria;
using CRM.Domain.Users.Objects.Entities;
using Linq.Abstractions.AsyncQueryable;
using Linq.Abstractions.Providers;
using Queries.Linq.Defaults;

namespace CRM.Persistence.ORM.Queries.Entities.Users
{
    public class FindUserByEmailQuery : LinqAsyncQueryBase<User, FindUserByEmail, User>
    {
        public FindUserByEmailQuery(ILinqProvider linqProvider, IAsyncQueryableFactory queryableFactory)
            : base(linqProvider, queryableFactory)
        {

        }

        public override Task<User> ExecuteAsync(FindUserByEmail criterion, CancellationToken cancellationToken = default)
        {
            return AsyncQuery.SingleOrDefaultAsync(u => u.Email == criterion.Email, cancellationToken);
        }
    }
}

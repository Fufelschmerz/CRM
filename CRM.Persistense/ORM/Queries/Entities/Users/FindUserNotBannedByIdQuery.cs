using System.Threading;
using System.Threading.Tasks;
using CRM.Domain.Users.Criteria;
using CRM.Domain.Users.Objects.Entities;
using Linq.Abstractions.AsyncQueryable;
using Linq.Abstractions.Providers;
using Queries.Linq.Defaults;

namespace CRM.Persistence.ORM.Queries.Entities.Users
{
    public class FindUserNotBannedByIdQuery : LinqAsyncQueryBase<User, FindUserNotBannedById, User>
    {
        public FindUserNotBannedByIdQuery(ILinqProvider linqProvider, IAsyncQueryableFactory queryableFactory)
            : base(linqProvider, queryableFactory)
        {

        }

        public override Task<User> ExecuteAsync(FindUserNotBannedById criterion, CancellationToken cancellationToken = default)
        {
            return AsyncQuery.SingleOrDefaultAsync(u => u.Id == criterion.Id && u.IsBlocked == false, cancellationToken);
        }
    }
}
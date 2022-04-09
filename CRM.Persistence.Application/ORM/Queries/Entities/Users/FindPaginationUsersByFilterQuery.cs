using System.Linq;
using CRM.Application.Controllers.Users.Actions.GetList;
using CRM.Application.Infrastructure.Pagination;
using CRM.Application.Infrastructure.Queries;
using CRM.Domain.Users.Objects.Entities;
using Queries.Linq.Defaults;
using System.Threading;
using System.Threading.Tasks;
using CRM.Application.Infrastructure.Queries.Defaults;
using Linq.Abstractions.AsyncQueryable;
using Linq.Abstractions.Providers;

namespace CRM.Persistence.Application.ORM.Queries.Entities.Users
{
    public class FindPaginationUsersByFilterQuery : LinqAsyncQueryBase<User, FindPaginationByFilter<GetUserListFilter>, PaginatedList<User>>
    {
        public FindPaginationUsersByFilterQuery(
            ILinqProvider linqProvider, IAsyncQueryableFactory asyncQueryableFactory)
            : base(linqProvider, asyncQueryableFactory)
        {

        }

        public override async Task<PaginatedList<User>> ExecuteAsync(FindPaginationByFilter<GetUserListFilter> criterion, CancellationToken cancellationToken = default)
        {
            var query = Query;

            if (criterion.Filter != null)
            {
                if (criterion.Filter.IsBlocked != null)
                {
                    query = query.Where(x => x.IsBlocked == criterion.Filter.IsBlocked);
                }

                if (criterion.Filter.Role != null)
                {
                    query = query.Where(x => x.UserRole == criterion.Filter.Role);
                }

                if (!string.IsNullOrWhiteSpace(criterion.Filter.Search))
                {
                    query = query.Where(x => x.Name.Contains(criterion.Filter.Search));
                }
            }

            int count = await ToAsync(query).CountAsync(cancellationToken);

            return new PaginatedList<User>(count,
                await ToAsync(query.OrderBy(x => x.Name).Skip(criterion.Offset).Take(criterion.Count))
                    .ToListAsync(cancellationToken));
        }
    }
}

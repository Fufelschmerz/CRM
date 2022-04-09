using System.Linq;
using CRM.Application.Controllers.States.Actions.GetList;
using CRM.Application.Infrastructure.Pagination;
using CRM.Application.Infrastructure.Queries;
using CRM.Domain.States.Objects.Entities;
using Linq.Abstractions.AsyncQueryable;
using Linq.Abstractions.Providers;
using Queries.Linq.Defaults;
using System.Threading;
using System.Threading.Tasks;
using CRM.Application.Infrastructure.Queries.Defaults;

namespace CRM.Persistence.Application.ORM.Queries.Entities.States
{
    public class FindPaginationStatesByFilterQuery : LinqAsyncQueryBase<State, FindPaginationByFilter<GetStateListFilter>, PaginatedList<State>>
    {
        public FindPaginationStatesByFilterQuery(
            ILinqProvider linqProvider, IAsyncQueryableFactory asyncQueryableFactory)
            : base(linqProvider, asyncQueryableFactory)
        {

        }

        public override async Task<PaginatedList<State>> ExecuteAsync(FindPaginationByFilter<GetStateListFilter> criterion, CancellationToken cancellationToken = default)
        {
            var query = Query;

            if (criterion.Filter != null)
            {
                if (criterion.Filter.IsArchive != null)
                {
                    query = query.Where(x => x.IsArchive == criterion.Filter.IsArchive);
                }

                if (criterion.Filter.Status != null)
                {
                    query = query.Where(x => x.Status == criterion.Filter.Status);
                }

                if (!string.IsNullOrWhiteSpace(criterion.Filter.Search))
                {
                    query = query.Where(x => x.Name.Contains(criterion.Filter.Search));
                }
            }

            int count = await ToAsync(query).CountAsync(cancellationToken);

            return new PaginatedList<State>(count,
                await ToAsync(query.OrderBy(x => x.Name).Skip(criterion.Offset).Take(criterion.Count))
                    .ToListAsync(cancellationToken));
        }
    }
}

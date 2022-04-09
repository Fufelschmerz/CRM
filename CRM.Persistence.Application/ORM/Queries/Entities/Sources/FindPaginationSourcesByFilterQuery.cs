using System.Linq;
using CRM.Application.Infrastructure.Pagination;
using CRM.Application.Infrastructure.Queries;
using CRM.Domain.Sources.Objects.Entities;
using Queries.Linq.Defaults;
using System.Threading;
using System.Threading.Tasks;
using CRM.Application.Controllers.Sources.Actions.GetList;
using CRM.Application.Infrastructure.Queries.Defaults;
using Linq.Abstractions.AsyncQueryable;
using Linq.Abstractions.Providers;

namespace CRM.Persistence.Application.ORM.Queries.Entities.Sources
{
    public class FindPaginationSourcesByFilterQuery : LinqAsyncQueryBase<Source, FindPaginationByFilter<GetSourceListFilter>, PaginatedList<Source>>
    {
        public FindPaginationSourcesByFilterQuery(
            ILinqProvider linqProvider, IAsyncQueryableFactory asyncQueryableFactory)
            : base(linqProvider, asyncQueryableFactory)
        {

        }

        public override async Task<PaginatedList<Source>> ExecuteAsync(FindPaginationByFilter<GetSourceListFilter> criterion, CancellationToken cancellationToken = default)
        {
            var query = Query;

            if (criterion.Filter != null)
            {
                if (criterion.Filter.IsArchive != null)
                {
                    query = query.Where(x => x.IsArchive == criterion.Filter.IsArchive);
                }

                if (!string.IsNullOrWhiteSpace(criterion.Filter.Search))
                {
                    query = query.Where(x => x.Name.Contains(criterion.Filter.Search));
                }
            }

            int count = await ToAsync(query).CountAsync(cancellationToken);

            return new PaginatedList<Source>(count, await ToAsync(query.OrderBy(x => x.Name).Skip(criterion.Offset).Take(criterion.Count)).ToListAsync(cancellationToken));
        }
    }
}

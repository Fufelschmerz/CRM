using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CRM.Application.Controllers.Customers.Actions.GetList;
using CRM.Application.Infrastructure.Pagination;
using CRM.Application.Infrastructure.Queries;
using CRM.Application.Infrastructure.Queries.Defaults;
using CRM.Domain.Customers.Objects.Entities;
using Linq.Abstractions.AsyncQueryable;
using Linq.Abstractions.Providers;
using Queries.Linq.Defaults;

namespace CRM.Persistence.Application.ORM.Queries.Entities.Customers
{
    public class FindPaginationCustomersByFilterQuery : LinqAsyncQueryBase<Customer, FindPaginationByFilter<GetCustomerListFilter>, PaginatedList<Customer>>
    {
        public FindPaginationCustomersByFilterQuery(
            ILinqProvider linqProvider, IAsyncQueryableFactory asyncQueryableFactory)
            : base(linqProvider, asyncQueryableFactory)
        {

        }

        public override async Task<PaginatedList<Customer>> ExecuteAsync(FindPaginationByFilter<GetCustomerListFilter> criterion, CancellationToken cancellationToken = default)
        {
            var query = Query;

            if (criterion.Filter != null)
            {
                if (criterion.Filter.StateId != null)
                {
                    query = Query.Where(x => x.State.Id == criterion.Filter.StateId);
                }

                if (!string.IsNullOrWhiteSpace(criterion.Filter.Search))
                {
                    query = Query.Where(x => x.Name.Contains(criterion.Filter.Search));
                }
            }

            int count = await ToAsync(query).CountAsync(cancellationToken);

            return new PaginatedList<Customer>(count,
                await ToAsync(query.OrderBy(x => x.Name).Skip(criterion.Offset).Take(criterion.Count))
                    .ToListAsync(cancellationToken));
        }
    }
}

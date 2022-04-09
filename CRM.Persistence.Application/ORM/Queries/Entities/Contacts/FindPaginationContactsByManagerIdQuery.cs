using System.Linq;
using CRM.Application.Infrastructure.Pagination;
using CRM.Application.Infrastructure.Queries.Entities.Contacts;
using CRM.Domain.Contacts.Objects.Entities;
using Queries.Linq.Defaults;
using System.Threading;
using System.Threading.Tasks;
using Linq.Abstractions.AsyncQueryable;
using Linq.Abstractions.Providers;

namespace CRM.Persistence.Application.ORM.Queries.Entities.Contacts
{
    public class FindPaginationContactsByManagerIdQuery : LinqAsyncQueryBase<Contact, FindPaginationContactsByManagerId, PaginatedList<Contact>>
    {
        public FindPaginationContactsByManagerIdQuery(
            ILinqProvider linqProvider, IAsyncQueryableFactory asyncQueryableFactory)
            : base(linqProvider, asyncQueryableFactory)
        {

        }

        public override async Task<PaginatedList<Contact>> ExecuteAsync(FindPaginationContactsByManagerId criterion, CancellationToken cancellationToken = default)
        {
            var query = Query.Where(x => x.Manager.Id == criterion.ManagerId);

            int count = await ToAsync(query).CountAsync(cancellationToken);

            return new PaginatedList<Contact>(count,
                await ToAsync(query.OrderBy(x => x.CreationOfDate).Skip(criterion.Offset).Take(criterion.Count))
                    .ToListAsync(cancellationToken));
        }
    }
}
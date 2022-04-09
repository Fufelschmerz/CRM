namespace CRM.Application.Controllers.Customers.Actions.Archive.Delete
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Requests.Handlers;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.Customers.Objects.Entities;
    using Queries.Abstractions.Builders;

    public class DeleteCustomerToArchiveRequestHandler :IAsyncRequestHandler<DeleteCustomerToArchiveRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        public DeleteCustomerToArchiveRequestHandler(IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task ExecuteAsync(DeleteCustomerToArchiveRequest request, CancellationToken cancellationToken = default)
        {
            var customer = await _queryBuilder.FindByIdAsync<Customer>(request.Id, cancellationToken);

            customer.DeleteCustomerToArchive();
        }
    }
}
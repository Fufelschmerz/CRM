namespace CRM.Application.Controllers.Customers.Actions.Delete
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Requests.Handlers;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.Customers.Objects.Entities;
    using CRM.Domain.Customers.Services.Abstractions;
    using Queries.Abstractions.Builders;
    using CRM.Application.Infrastructure.Exceptions.Customers;

    public class DeleteCustomerRequestHandler : IAsyncRequestHandler<DeleteCustomerRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        private readonly ICustomerService _customerService;

        public DeleteCustomerRequestHandler(IAsyncQueryBuilder queryBuilder, ICustomerService customerService)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));

            _customerService = customerService ??
                               throw new ArgumentNullException(nameof(customerService));
        }

        public async Task ExecuteAsync(DeleteCustomerRequest request, CancellationToken cancellationToken = default)
        {
            var customer = await _queryBuilder.FindByIdAsync<Customer>(request.Id, cancellationToken) ??
                           throw new CustomerNotFoundException();

            await _customerService.DeleteCustomerAsync(customer, cancellationToken);
        }
    }
}
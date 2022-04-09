namespace CRM.Application.Controllers.Customers.Actions.Edit
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Requests.Handlers;
    using CRM.Application.Infrastructure.Exceptions.Customers;
    using CRM.Application.Infrastructure.Exceptions.Sources;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.Customers.Objects.Entities;
    using CRM.Domain.Customers.Services.Abstractions;
    using CRM.Domain.Sources.Objects.Entities;
    using CRM.Domain.States.Exceptions;
    using CRM.Domain.States.Objects.Entities;
    using Queries.Abstractions.Builders;

    public class EditCustomerRequestHandler : IAsyncRequestHandler<EditCustomerRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;


        public EditCustomerRequestHandler(IAsyncQueryBuilder queryBuilder)
        {

            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task ExecuteAsync(EditCustomerRequest request, CancellationToken cancellationToken = default)
        {
            var customer = await _queryBuilder.FindByIdAsync<Customer>(request.Id, cancellationToken) ??
                           throw new CustomerNotFoundException();

            var source = await _queryBuilder.FindByIdAsync<Source>(request.SourceId, cancellationToken) ??
                         throw new SourceNotFoundException();

            var state = await _queryBuilder.FindByIdAsync<State>(request.StateId, cancellationToken) ??
                        throw new StateNotFoundException();

            customer.CreateOrEditCustomer(request.Name, source, state, request.Description);
        }
    }
}
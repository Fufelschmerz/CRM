namespace CRM.Application.Controllers.Customers.Actions.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Requests.Handlers;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.Customers.Services.Abstractions;
    using CRM.Domain.Sources.Objects.Entities;
    using Queries.Abstractions.Builders;
    using CRM.Application.Infrastructure.Exceptions.Sources;
    using CRM.Domain.States.Exceptions;
    using CRM.Domain.States.Objects.Entities;

    public class CreateCustomerRequestHandler : IAsyncRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        private readonly ICustomerService _customerService;

        private readonly IAsyncQueryBuilder _queryBuilder;

        public CreateCustomerRequestHandler(ICustomerService customerService, IAsyncQueryBuilder queryBuilder)
        {
            _customerService = customerService ??
                               throw new ArgumentNullException(nameof(customerService));

            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task<CreateCustomerResponse> ExecuteAsync(CreateCustomerRequest request, CancellationToken cancellationToken = default)
        {
            var source = await _queryBuilder.FindByIdAsync<Source>(request.SourceId, cancellationToken) ??
                         throw new SourceNotFoundException();

            var state = await _queryBuilder.FindByIdAsync<State>(request.StateId, cancellationToken) ??
                        throw new StateNotFoundException();

            var customer = await _customerService.CreateCustomerAsync(request.Name, source, state, request.Description, cancellationToken);

            return new CreateCustomerResponse {Id = customer.Id};
        }
    }
}
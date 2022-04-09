namespace CRM.Application.Controllers.States.Actions.Delete
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Requests.Handlers;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.States.Objects.Entities;
    using CRM.Domain.States.Services.Abstractions;
    using Queries.Abstractions.Builders;
    using CRM.Application.Infrastructure.Exceptions.States;

    public class DeleteStateRequestHandler : IAsyncRequestHandler<DeleteStateRequest>
    {
        private readonly IStateService _stateService;

        private readonly IAsyncQueryBuilder _queryBuilder;

        public DeleteStateRequestHandler(IStateService stateService, IAsyncQueryBuilder queryBuilder)
        {
            _stateService = stateService ??
                throw new ArgumentNullException(nameof(stateService));

            _queryBuilder = queryBuilder ??
                throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task ExecuteAsync(DeleteStateRequest request, CancellationToken cancellationToken = default)
        {
            var state = await _queryBuilder.FindByIdAsync<State>(request.Id, cancellationToken) ?? 
                        throw new StateNotFoundException();

            await _stateService.DeleteStateAsync(state, cancellationToken);
        }
    }
}

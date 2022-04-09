namespace CRM.Application.Controllers.States.Actions.Edit
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Requests.Handlers;
    using CRM.Application.Infrastructure.Exceptions.States;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.States.Objects.Entities;
    using CRM.Domain.States.Services.Abstractions;
    using Queries.Abstractions.Builders;

    public class EditStateRequestHandler :  IAsyncRequestHandler<EditStateRequest>
    {
        private readonly IStateService _stateService;

        private readonly IAsyncQueryBuilder _queryBuilder;

        public EditStateRequestHandler(IStateService stateService, IAsyncQueryBuilder queryBuilder)
        {
            _stateService = stateService ??
                throw new ArgumentNullException(nameof(stateService));

            _queryBuilder = queryBuilder ??
                throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task ExecuteAsync(EditStateRequest request, CancellationToken cancellationToken = default)
        {
            var state = await _queryBuilder.FindByIdAsync<State>(request.Id, cancellationToken)
                ?? throw new StateNotFoundException();

            await _stateService.EditStateAsync(state, request.Name.Trim(), request.Status, cancellationToken);
        }
    }
}

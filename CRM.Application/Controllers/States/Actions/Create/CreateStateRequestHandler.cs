using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Requests.Handlers;
using CRM.Domain.States.Services.Abstractions;

namespace CRM.Application.Controllers.States.Actions.Create
{
    public class CreateStateRequestHandler : IAsyncRequestHandler<CreateStateRequest, CreateStateResponse>
    {
        private readonly IStateService _stateService;

        public CreateStateRequestHandler(IStateService stateService)
        {
            _stateService = stateService ??
                throw new ArgumentNullException(nameof(stateService));
        }

        public async Task<CreateStateResponse> ExecuteAsync(CreateStateRequest request, CancellationToken cancellationToken = default)
        {
            var state = await _stateService.CreateStateAsync(request.Name.Trim(), request.Status, cancellationToken);

            return new CreateStateResponse { Id = state.Id };
        }
    }
}

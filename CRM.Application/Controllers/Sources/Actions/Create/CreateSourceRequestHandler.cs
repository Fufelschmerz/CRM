namespace CRM.Application.Controllers.Sources.Actions.Create
{
    using Api.Requests.Handlers;
    using CRM.Domain.Sources.Services.Abstractions;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateSourceRequestHandler : IAsyncRequestHandler<CreateSourceRequest, CreateSourceResponse>
    {
        private readonly ISourceService _sourceService;

        public CreateSourceRequestHandler(ISourceService sourceService)
        {
            _sourceService = sourceService ??
                throw new ArgumentException(nameof(sourceService));
        }

        public async Task<CreateSourceResponse> ExecuteAsync(CreateSourceRequest request, CancellationToken cancellationToken = default)
        {
            var source = await _sourceService.CreateSourceAsync(request.Name, cancellationToken);

            return new CreateSourceResponse { Id = source.Id };
        }
    }
}

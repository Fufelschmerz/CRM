namespace CRM.Application.Controllers.Sources.Actions.Edit
{
    using Api.Requests.Handlers;
    using CRM.Application.Infrastructure.Exceptions.Sources;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.Sources.Objects.Entities;
    using CRM.Domain.Sources.Services.Abstractions;
    using Queries.Abstractions.Builders;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditSourceRequestHandler : IAsyncRequestHandler<EditSourceRequest>
    {
        private readonly ISourceService _sourceService;

        private readonly IAsyncQueryBuilder _queryBuilder;

        public EditSourceRequestHandler(ISourceService sourceService, IAsyncQueryBuilder queryBuilder)
        {
            _sourceService = sourceService ??
                throw new ArgumentNullException(nameof(sourceService));
            _queryBuilder = queryBuilder ??
                throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task ExecuteAsync(EditSourceRequest request, CancellationToken cancellationToken = default)
        {
            var source = await _queryBuilder.FindByIdAsync<Source>(request.Id, cancellationToken) ??
                throw new SourceNotFoundException();

            await _sourceService.EditSourceAsync(source, request.Name, cancellationToken);
        }
    }
}

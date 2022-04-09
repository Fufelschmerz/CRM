using CRM.Application.Infrastructure.Exceptions.Sources;

namespace CRM.Application.Controllers.Sources.Actions.Archive.Delete
{
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.Sources.Objects.Entities;
    using System.Threading;
    using System.Threading.Tasks;
    using System;
    using Queries.Abstractions.Builders;
    using Api.Requests.Handlers;

    public class DeleteSourceToArchiveRequestHandler : IAsyncRequestHandler<DeleteSourceToArchiveRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        public DeleteSourceToArchiveRequestHandler(IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));
        }


        public async Task ExecuteAsync(DeleteSourceToArchiveRequest request, CancellationToken cancellationToken = default)
        {
            var source = await _queryBuilder.FindByIdAsync<Source>(request.Id, cancellationToken) ??
                         throw new SourceNotFoundException();

            source.DeleteSourceToArchive();
        }
    }
}
namespace CRM.Application.Controllers.States.Actions.Archive.Delete
{
    using CRM.Application.Infrastructure.Exceptions.States;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.States.Objects.Entities;
    using Api.Requests.Handlers;
    using Queries.Abstractions.Builders;
    using System.Threading;
    using System.Threading.Tasks;
    using System;

    public class DeleteStateToArchiveRequestHandler : IAsyncRequestHandler<DeleteStateToArchiveRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        public DeleteStateToArchiveRequestHandler(IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task ExecuteAsync(DeleteStateToArchiveRequest request, CancellationToken cancellationToken = default)
        {
            var state = await _queryBuilder.FindByIdAsync<State>(request.Id, cancellationToken) ??
                        throw new StateNotFoundException();

            state.DeleteStateToArchive();
        }
    }
}
namespace CRM.Application.Controllers.States.Actions.Archive.Add
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Requests.Handlers;
    using CRM.Application.Infrastructure.Exceptions.States;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.States.Objects.Entities;
    using Queries.Abstractions.Builders;

    public class AddStateToArchiveRequestHandler : IAsyncRequestHandler<AddStateToArchiveRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        public AddStateToArchiveRequestHandler(IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ??
                throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task ExecuteAsync(AddStateToArchiveRequest request, CancellationToken cancellationToken = default)
        {
            var state = await _queryBuilder.FindByIdAsync<State>(request.Id, cancellationToken) ?? 
                        throw new StateNotFoundException();

            state.AddStateToArchive();
        }
    }
}

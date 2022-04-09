namespace CRM.Application.Controllers.Users.Actions.Blocking.Block
{
    using Api.Requests.Handlers;
    using CRM.Application.Infrastructure.Exceptions.Users;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.Users.Objects.Entities;
    using Queries.Abstractions.Builders;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class BlockUserRequestHandler : IAsyncRequestHandler<BlockUserRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        public BlockUserRequestHandler(IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ??
                throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task ExecuteAsync(BlockUserRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _queryBuilder.FindByIdAsync<User>(request.Id, cancellationToken)
                ?? throw new UserNotFoundException();

            user.BlockUser();
        }
    }
}

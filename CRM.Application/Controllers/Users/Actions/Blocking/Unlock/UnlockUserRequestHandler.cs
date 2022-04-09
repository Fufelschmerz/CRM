namespace CRM.Application.Controllers.Users.Actions.Blocking.Unlock
{
    using Api.Requests.Handlers;
    using CRM.Application.Infrastructure.Exceptions.Users;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.Users.Objects.Entities;
    using Queries.Abstractions.Builders;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class UnlockUserRequestHandler : IAsyncRequestHandler<UnlockUserRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        public UnlockUserRequestHandler(IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ??
                throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task ExecuteAsync(UnlockUserRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _queryBuilder.FindByIdAsync<User>(request.Id, cancellationToken) ??
                throw new UserNotFoundException();

            user.UnlockUser();
        }
    }
}

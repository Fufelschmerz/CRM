namespace CRM.Application.Controllers.Users.Actions.Delete
{
    using Api.Requests.Handlers;
    using CRM.Application.Infrastructure.Exceptions.Users;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.Users.Objects.Entities;
    using CRM.Domain.Users.Services.Abstractions;
    using Queries.Abstractions.Builders;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteUserRequestHandler : IAsyncRequestHandler<DeleteUserRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        private readonly IUserService _userService;

        public DeleteUserRequestHandler(IAsyncQueryBuilder queryBuilder, IUserService userService)
        {
            _queryBuilder = queryBuilder ??
                throw new ArgumentNullException(nameof(queryBuilder));

            _userService = userService ??
                throw new ArgumentNullException(nameof(userService));
        }

        public async Task ExecuteAsync(DeleteUserRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _queryBuilder.FindByIdAsync<User>(request.Id, cancellationToken) ??
                throw new UserNotFoundException();

            await _userService.DeleteUserAsync(user, cancellationToken);
        }
    }
}

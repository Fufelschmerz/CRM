namespace CRM.Application.Controllers.Users.Actions.Edit
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

    public class EditUserRequestHandler : IAsyncRequestHandler<EditUserRequest>
    {
        private readonly IUserService _userService;

        private readonly IAsyncQueryBuilder _queryBuilder;

        public EditUserRequestHandler(IUserService userService, IAsyncQueryBuilder queryBuilder)
        {
            _userService = userService ??
                throw new ArgumentNullException(nameof(userService));

            _queryBuilder = queryBuilder ??
                throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task ExecuteAsync(EditUserRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _queryBuilder.FindByIdAsync<User>(request.Id) ??
                throw new UserNotFoundException();

            await _userService.EditUserAsync(user, request.Email.Trim(), request.Name, request.UserRole, cancellationToken);
        }
    }
}

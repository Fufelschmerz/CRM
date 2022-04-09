namespace CRM.Application.Controllers.Users.Actions.Create
{
    using Api.Requests.Handlers;
    using CRM.Domain.Users.Services.Abstractions;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateUserRequestHandler : IAsyncRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserService _userService;

        public CreateUserRequestHandler(IUserService userService)
        {
            _userService = userService ??
                throw new ArgumentNullException(nameof(userService));
        }

        public async Task<CreateUserResponse> ExecuteAsync(CreateUserRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _userService.CreateUserAsync(request.Email.Trim(), request.Name, request.Password, request.Role, cancellationToken);

            return new CreateUserResponse { Id = user.Id };
        }
    }
}

namespace CRM.Application.Controllers.Admins.Actions.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Requests.Handlers;
    using CRM.Domain.Users.Enums;
    using CRM.Domain.Users.Services.Abstractions;

    public class CreateFirstAdminRequestHandler: IAsyncRequestHandler<CreateFirstAdminRequest>
    {
        private readonly IUserService _userService;

        public CreateFirstAdminRequestHandler(IUserService userService)
        {
            _userService = userService ??
                           throw new ArgumentNullException(nameof(userService));
        }

        public async Task ExecuteAsync(CreateFirstAdminRequest request, CancellationToken cancellationToken = default)
        {
            _= await _userService.CreateUserAsync(request.Email.Trim(), request.Name, request.Password, UserRoles.Admin, cancellationToken);
        }
    }
}
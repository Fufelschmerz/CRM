namespace CRM.Application.Controllers.Users.Actions.ChangePassword
{
    using Api.Requests.Handlers;
    using CRM.Application.Infrastructure.Authorization.Providers;
    using CRM.Application.Infrastructure.Exceptions.Accounts;
    using CRM.Application.Infrastructure.Exceptions.Users;
    using CRM.Domain.Users.Objects.Entities;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class ChangePasswordRequestHandler : IAsyncRequestHandler<ChangePasswordRequest>
    {
        private readonly IAsyncUserProvider<User> _userProvider;

        public ChangePasswordRequestHandler(IAsyncUserProvider<User> userProvider)
        {
            _userProvider = userProvider ??
                throw new ArgumentNullException(nameof(userProvider));
        }

        public async Task ExecuteAsync(ChangePasswordRequest request, CancellationToken cancellationToken = default)
        {
            if (request.NewPassword == request.OldPassword)
                throw new MatchingNewAndOldPasswordException();

            var user = await _userProvider.GetUserAsync(cancellationToken);

            if (!user.Password.Check(request.OldPassword))
                throw new PasswordIsIncorrectException("The old password was entered incorrectly");

            user.SetPassword(request.NewPassword);
        }
    }
}

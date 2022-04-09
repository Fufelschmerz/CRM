using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Requests.Handlers;
using CRM.Application.Infrastructure.Authentication;
using CRM.Domain.Users.Objects.Entities;

namespace CRM.Application.Controllers.Accounts.Actions.SignOut
{
    public class SignOutHandler : IAsyncRequestHandler<SignOutRequest>
    {
        private readonly IAsyncAuthenticationService<User> _authenticationService;

        public SignOutHandler(IAsyncAuthenticationService<User> authenticationService)
        {
            _authenticationService = authenticationService ??
                                     throw new ArgumentNullException(nameof(authenticationService));
        }

        public async Task ExecuteAsync(SignOutRequest request, CancellationToken cancellationToken = default)
        {
            await _authenticationService.SignOutAsync(cancellationToken);
        }
    }
}
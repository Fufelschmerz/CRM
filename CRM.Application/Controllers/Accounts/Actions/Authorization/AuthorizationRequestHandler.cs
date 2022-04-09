using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Requests.Handlers;
using CRM.Application.Infrastructure.Authorization.Providers;
using CRM.Domain.Users.Objects.Entities;

namespace CRM.Application.Controllers.Accounts.Actions.Authorization
{
    public class AuthorizationRequestHandler : IAsyncRequestHandler<AuthorizationRequest, AuthorizationResponse>
    {
        private readonly IAsyncUserProvider<User> _userProvider;

        public AuthorizationRequestHandler(IAsyncUserProvider<User> userProvider)
        {
            _userProvider = userProvider ??
                            throw new ArgumentNullException(nameof(userProvider));
        }

        public async Task<AuthorizationResponse> ExecuteAsync(AuthorizationRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _userProvider.GetUserAsync(cancellationToken);

            return new AuthorizationResponse(user != null);
        }
    }
}
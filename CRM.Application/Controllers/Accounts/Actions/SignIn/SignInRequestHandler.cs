using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Requests.Handlers;
using CRM.Application.Infrastructure.Authentication;
using CRM.Application.Infrastructure.Exceptions.Accounts;
using CRM.Domain.Users.Criteria;
using CRM.Domain.Users.Objects.Entities;
using Queries.Abstractions.Builders;

namespace CRM.Application.Controllers.Accounts.Actions.SignIn
{
    public class SignInRequestHandler:IAsyncRequestHandler<SignInRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        private readonly IAsyncAuthenticationService<User> _authenticationService;

        public SignInRequestHandler(IAsyncQueryBuilder queryBuilder, IAsyncAuthenticationService<User> authenticationService)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));

            _authenticationService = authenticationService ??
                                     throw new ArgumentNullException((nameof(authenticationService)));

        }

        public async Task ExecuteAsync(SignInRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _queryBuilder.For<User>()
                           .WithAsync(new FindUserByEmail(request.Email), cancellationToken) ??
                       throw new EmailIsIncorrectException();

            if (!user.Password.Check(request.Password))
                throw new PasswordIsIncorrectException(); 

            await _authenticationService.SignInAsync(user, cancellationToken);

        }
    }
}
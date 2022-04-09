using CRM.Application.Infrastructure.Authorization.Providers;

namespace CRM.Application.Authorization.Requirements.Handlers
{
    using System;
    using System.Threading.Tasks;
    using Domain.Users.Objects.Entities;
    using Microsoft.AspNetCore.Authorization;

    public class UserRequirementHandler : AuthorizationHandler<UserRequirement>
    {
        private readonly IAsyncUserProvider<User> _userProvider;


        public UserRequirementHandler(IAsyncUserProvider<User> userProvider)
        {
            _userProvider = userProvider ??
                            throw new ArgumentNullException(nameof(userProvider));
        }


        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            UserRequirement requirement)
        {
            var user = await _userProvider.GetUserAsync();

            if (user != null)
                context.Succeed(requirement);
        }
    }
}
using System.Threading.Tasks;
using CRM.Domain.Users.Enums;

namespace CRM.Application.Authorization.Requirements.Handlers
{
    using System;
    using CRM.Application.Infrastructure.Authorization.Providers;
    using CRM.Domain.Users.Objects.Entities;
    using Microsoft.AspNetCore.Authorization;

    public class ManagerOrUserRequirementHandler : AuthorizationHandler<ManagerOrAdminRequirement>
    {
        private readonly IAsyncUserProvider<User> _userProvider;

        public ManagerOrUserRequirementHandler(IAsyncUserProvider<User> userProvider)
        {
            _userProvider = userProvider ??
                            throw new ArgumentNullException(nameof(userProvider));
        }


        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            ManagerOrAdminRequirement requirement)
        {
            var user = await _userProvider.GetUserAsync();

            if(user != null && (user.UserRole == UserRoles.Admin || user.UserRole == UserRoles.Manager))
                context.Succeed(requirement);
        }
    }
}
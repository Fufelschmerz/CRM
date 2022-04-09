namespace CRM.Application.Authorization.Requirements.Handlers
{
    using System;
    using System.Threading.Tasks;
    using CRM.Application.Infrastructure.Authorization.Providers;
    using CRM.Domain.Users.Enums;
    using CRM.Domain.Users.Objects.Entities;
    using Microsoft.AspNetCore.Authorization;

    public class AdminRequirementHandler : AuthorizationHandler<AdminRequirement>
    {
        private readonly IAsyncUserProvider<User> _userProvider;


        public AdminRequirementHandler(IAsyncUserProvider<User> userProvider)
        {
            _userProvider = userProvider ?? 
                throw new ArgumentNullException(nameof(userProvider));
        }


        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            AdminRequirement requirement)
        {
            var user = await _userProvider.GetUserAsync();

            if (user != null && user.UserRole == UserRoles.Admin)
                context.Succeed(requirement);
        }
    }
}
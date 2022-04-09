namespace CRM.WebApi.DI.Microsoft.Extensions.Authorization
{
    using CRM.Application.Authorization;
    using CRM.Application.Authorization.Requirements;
    using global::Microsoft.Extensions.DependencyInjection;

    public static class AuthorizationExtensions
    {
        public static IServiceCollection ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    Policies.User,
                    policy => policy
                        .AddAuthenticationSchemes(Schemes.UserScheme)
                        .AddRequirements(new UserRequirement()));

                options.AddPolicy(
                    Policies.Admin,
                    policy => policy
                        .AddAuthenticationSchemes(Schemes.UserScheme)
                        .AddRequirements(new AdminRequirement()));

                options.AddPolicy(
                    Policies.ManagerOrAdmin,
                    policy => policy.AddAuthenticationSchemes(Schemes.UserScheme)
                        .AddRequirements(new ManagerOrAdminRequirement()));
            });

            return services;
        }
    }
}
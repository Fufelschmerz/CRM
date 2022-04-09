namespace CRM.WebApi.DI.Microsoft.Extensions.Authorization
{
    using CRM.Application.Authorization;
    using global::Microsoft.AspNetCore.Authentication.Cookies;
    using global::Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    public static class AuthenticationExtensions
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthentication()
                .AddCookie(Schemes.UserScheme, options =>
                {
                    options.Cookie.Name = "CrmCookie";
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = context =>
                        {
                            context.Response.StatusCode = 401;
                            return Task.CompletedTask;
                        },
                        OnRedirectToAccessDenied = context =>
                        {
                            context.Response.StatusCode = 401;
                            return Task.CompletedTask;
                        }
                    };
                });

            return services;
        }
    }
}
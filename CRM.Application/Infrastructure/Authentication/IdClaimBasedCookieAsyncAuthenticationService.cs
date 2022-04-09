namespace CRM.Application.Infrastructure.Authentication
{
    using System;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using global::Domain.Abstracions.Entities;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Http;

    public class IdClaimBasedCookieAsyncAuthenticationService<TUser> : IAsyncAuthenticationService<TUser>
        where TUser : class, IEntity, new()
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _scheme;


        public IdClaimBasedCookieAsyncAuthenticationService(
            IHttpContextAccessor httpContextAccessor,
            string scheme)
        {
            if (string.IsNullOrWhiteSpace(scheme))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(scheme));

            _httpContextAccessor = httpContextAccessor ?? 
                                   throw new ArgumentNullException(nameof(httpContextAccessor));
            _scheme = scheme;
        }


        public Task SignInAsync(TUser user, CancellationToken cancellationToken = default)
        {
            Claim[] claims =
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.Integer64)
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, "Cookie");

            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            return _httpContextAccessor.HttpContext.SignInAsync(_scheme, principal, new AuthenticationProperties
            {
                IsPersistent = true
            });
        }

        public Task SignOutAsync(CancellationToken cancellationToken = default)
        {
            return _httpContextAccessor.HttpContext.SignOutAsync(_scheme);
        }
    }
}
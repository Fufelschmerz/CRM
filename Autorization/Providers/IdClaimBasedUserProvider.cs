namespace Autorization.Providers
{
    using Autorization.Providers.Defaults;
    using CRM.Domain.Users.Criteria;
    using CRM.Domain.Users.Objects.Entities;
    using Domain.Abstracions.Entities;
    using Microsoft.AspNetCore.Http;
    using Queries.Abstractions.Builders;
    using System;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;

    public class IdClaimBasedUserProvider<TUser> : AsyncUserProviderDefault<TUser>
        where TUser : class, IEntity, new()
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAsyncQueryBuilder _queryBuilder;

        private TUser _user;


        public IdClaimBasedUserProvider(
            IHttpContextAccessor httpContextAccessor,
            IAsyncQueryBuilder queryBuilder)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
        }


        protected override async Task<TUser> GetUserAsync(CancellationToken cancellationToken = default)
        {
            if (_user != null)
                return _user;

            if (_httpContextAccessor.HttpContext.User.Identity == null ||
                !_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                return default;

            var nameIdentifierClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            if (nameIdentifierClaim == null)
                return default;

            if (!long.TryParse(nameIdentifierClaim.Value, out long id))
                return default;

            var user = await _queryBuilder.For<User>()
                .WithAsync(new FindUserNotBannedById(id), cancellationToken);

            if(user != null)
                _user = await _queryBuilder.FindByIdQuery<TUser>(id);

            return _user;
        }
    }
}

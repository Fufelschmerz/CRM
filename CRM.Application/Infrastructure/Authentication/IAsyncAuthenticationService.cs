namespace CRM.Application.Infrastructure.Authentication
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IAsyncAuthenticationService<in TUser>
    {
        Task SignInAsync(TUser user, CancellationToken cancellationToken = default);

        Task SignOutAsync(CancellationToken cancellationToken = default);
    }
}
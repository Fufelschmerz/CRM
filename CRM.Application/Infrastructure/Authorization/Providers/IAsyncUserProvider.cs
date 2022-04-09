using System.Threading;
using System.Threading.Tasks;

namespace CRM.Application.Infrastructure.Authorization.Providers
{
    public interface IAsyncUserProvider<TUser>
    {
        Task<TUser> GetUserAsync(CancellationToken cancellationToken = default);
    }
}

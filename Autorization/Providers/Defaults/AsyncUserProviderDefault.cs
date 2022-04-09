namespace Autorization.Providers.Defaults
{
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class AsyncUserProviderDefault<TUser> : IAsyncUserProvider<TUser>
    {
        public Task<TUser> User => GetUserAsync();

        protected abstract Task<TUser> GetUserAsync(CancellationToken cancellationToken = default);
    }
}

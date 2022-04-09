namespace Autorization.Providers
{
    using System.Threading.Tasks;

    public interface IAsyncUserProvider<TUser>
    {
        Task<TUser> User { get; }
    }
}

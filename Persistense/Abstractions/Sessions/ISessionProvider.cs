using NHibernate;

namespace Persistence.Abstractions.Sessions
{
    public interface ISessionProvider
    {
        ISession CurrentSession { get; }
    }
}

using NHibernate;

namespace Persistence.Sessions
{
    public interface ISessionProvider
    {
        ISession CurrentSession { get; }
    }

}

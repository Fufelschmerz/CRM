using System;
using System.Linq;
using Domain.Abstracions.Identification;
using Linq.Abstractions.Providers;
using Persistence.Sessions;

namespace ORM.Infrastructure.Linq.Providers
{
    public class NHibernateLinqProvider : ILinqProvider
    {
        private readonly ISessionProvider _sessionProvider;


        public NHibernateLinqProvider(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider 
                ?? throw new ArgumentNullException(nameof(sessionProvider));
        }


        public IQueryable<THasId> Query<THasId>() where THasId : class, IHasId, new()
        {
            return _sessionProvider.CurrentSession.Query<THasId>();
        }
    }
}

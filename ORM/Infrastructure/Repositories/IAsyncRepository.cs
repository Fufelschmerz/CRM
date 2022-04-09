using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Abstracions.Identification;
using NHibernate;
using Persistence.Sessions;
using Repositories.Abstractions;

namespace ORM.Infrastructure.Repositories
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class, IHasId, new()
    {
        private readonly ISessionProvider _session;

        public AsyncRepository(ISessionProvider session)
        {
            _session = session ??
                throw new ArgumentNullException(nameof(session));
        }

        private ISession Session => _session.CurrentSession;

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Session.SaveAsync(entity, cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Session.DeleteAsync(entity, cancellationToken);
        }
    }
}

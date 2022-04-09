using System;
using NHibernate;
using Persistence.Transactions.Behaviors;

namespace ORM.Infrastructure.Sessions
{
    public class ExpectCommitScopedSessionProvider : ScopedSessionProviderBase, IExpectCommit
    {
        public ExpectCommitScopedSessionProvider(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        public void PerformCommit()
        {
            if (Disposed)
                throw new InvalidOperationException("Object already disposed");

            try
            {
                CommitTransaction();
            }
            catch
            {
                RollbackTransaction();

                throw;
            }
            finally
            {
                Dispose();
            }
        }
    }
}

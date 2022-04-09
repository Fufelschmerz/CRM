using Linq.Abstractions.AsyncQueryable;
using System.Linq;

namespace NHibernate.Infrastructure.Linq.AsyncQueryable.Factories
{
    public class NHibernateAsyncQueryableFactory : IAsyncQueryableFactory
    {
        public IAsyncQueryable<T> CreateFrom<T>(IQueryable<T> query) => new NHibernateAsyncQueryable<T>(query);
    }
}

using System.Linq;
using Linq.Abstractions.AsyncQueryable;

namespace ORM.Infrastructure.Linq.AsyncQueryable.Factories
{
    public class NHibernateAsyncQueryableFactory : IAsyncQueryableFactory
    {
        public IAsyncQueryable<T> CreateFrom<T>(IQueryable<T> query) => new NHibernateAsyncQueryable<T>(query);
    }
}

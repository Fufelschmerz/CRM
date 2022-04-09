using Autofac;
using Autofac.Extensions.ConfiguredModules;
using CRM.Persistence.NHibernate;
using Linq.Abstractions.AsyncQueryable;
using Linq.Abstractions.Providers;
using Microsoft.Extensions.Configuration;
using ORM.Infrastructure.Linq.AsyncQueryable.Factories;
using ORM.Infrastructure.Linq.Providers;
using ORM.Infrastructure.Repositories;
using ORM.Infrastructure.Sessions;
using Persistence.Sessions;
using Persistence.Transactions.Behaviors;
using Repositories.Abstractions;

namespace CRM.WebApi.DI.Autofac.Modules
{
    public class PersistenceModule : ConfiguredModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            string connectionString = Configuration.GetConnectionString("CrmConnectionString");

            builder
                .RegisterGeneric(typeof(AsyncRepository<>))
                .As(typeof(IAsyncRepository<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterType<NHibernateLinqProvider>()
                .As<ILinqProvider>()
                .InstancePerDependency();

            builder
                .RegisterType<ExpectCommitScopedSessionProvider>()
                .As<ISessionProvider>()
                .As<IExpectCommit>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<NHibernateAsyncQueryableFactory>()
                .As<IAsyncQueryableFactory>()
                .SingleInstance();

            builder
                .RegisterType<NHibernateInitializer>()
                .AsSelf()
                .SingleInstance()
                .WithParameter("connectionString", connectionString);

            builder
                .Register(context => context.Resolve<NHibernateInitializer>().GetConfiguration().BuildSessionFactory())
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}

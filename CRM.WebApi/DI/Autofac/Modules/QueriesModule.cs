using Autofac;
using CRM.Persistence;
using CRM.Persistence.Application;
using CRM.Persistence.ORM.Queries.Defaults;
using Queries.Abstractions.Builders;
using Queries.Abstractions.Factories;
using Queries.Abstractions.Queries;
using Queries.Defaults;
using Tados.Autofac.Extensions.TypedFactories;

namespace CRM.WebApi.DI.Autofac.Modules
{
    public class QueriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(FindByIdQuery<>))
                .As(typeof(IAsyncQuery<,>))
                .InstancePerDependency();

            builder
                .RegisterGeneric(typeof(FindAllQuery<>))
                .As(typeof(IAsyncQuery<,>))
                .InstancePerDependency();

            builder
                .RegisterAssemblyTypes(typeof(PersistenceAssemblyMarker).Assembly)
                .AsClosedTypesOf(typeof(IAsyncQuery<,>))
                .InstancePerDependency();
            
            builder
                .RegisterAssemblyTypes(typeof(ApplicationPersistenceAssemblyMarker).Assembly)
                .AsClosedTypesOf(typeof(IAsyncQuery<,>))
                .InstancePerDependency();

            builder
                .RegisterGeneric(typeof(DefaultAsyncQueryFor<>))
                .As(typeof(IAsyncQueryFor<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterGenericTypedFactory<IAsyncQueryFactory>()
                .InstancePerLifetimeScope();

            builder
                .RegisterGenericTypedFactory<IAsyncQueryBuilder>()
                .InstancePerLifetimeScope();
        }
    }
}

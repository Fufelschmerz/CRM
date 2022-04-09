using CRM.Persistence;
using CRM.Persistence.ORM.Commands.Defaults;

namespace CRM.WebApi.DI.Autofac.Modules
{
    using global:: Autofac;
    using Commands.Absctractions.Builders;
    using Commands.Absctractions.Commands;
    using Commands.Absctractions.Factories;
    using Commands.Defaults.Builders;
    using Tados.Autofac.Extensions.TypedFactories;


    public class CommandsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(CreateObjWithIdCommand<>))
                .As(typeof(IAsyncCommand<>))
                .InstancePerDependency();

            builder
                .RegisterGeneric(typeof(DeleteObjWithIdCommand<>))
                .As(typeof(IAsyncCommand<>))
                .InstancePerDependency();

            builder
                .RegisterAssemblyTypes(typeof(PersistenceAssemblyMarker).Assembly)
                .AsClosedTypesOf(typeof(IAsyncCommand<>))
                .InstancePerDependency();

            builder
                .RegisterGenericTypedFactory<IAsyncCommandFactory>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<AsyncCommandBuilder>()
                .As<IAsyncCommandBuilder>()
                .InstancePerLifetimeScope();
        }
    }
}

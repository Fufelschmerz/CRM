namespace CRM.WebApi.DI.Autofac.Modules
{
    using Api.Requests.Builders.Abstractions;
    using Api.Requests.Builders.Defaults;
    using Api.Requests.Factory;
    using Api.Requests.Handlers;
    using global::Autofac;
    using Application;
    using Tados.Autofac.Extensions.TypedFactories;

    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(ApplicationAssemblyMarker).Assembly)
                .AsClosedTypesOf(typeof(IAsyncRequestHandler<>))
                .InstancePerDependency();

            builder
                .RegisterAssemblyTypes(typeof(ApplicationAssemblyMarker).Assembly)
                .AsClosedTypesOf(typeof(IAsyncRequestHandler<,>))
                .InstancePerDependency();

            builder
                .RegisterGenericTypedFactory<IAsyncRequestHandlerFactory>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<DefaultAsyncRequestBuilder>()
                .As<IAsyncRequestBuilder>()
                .InstancePerLifetimeScope();
        }
    }
}

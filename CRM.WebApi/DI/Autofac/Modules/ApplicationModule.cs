namespace CRM.WebApi.DI.Autofac.Modules
{
    using global::Application.Services;
    using global::Autofac;
    using Application;

    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(ApplicationAssemblyMarker).Assembly)
                .AssignableTo<IApplicationService>()
                .AsImplementedInterfaces()
                .InstancePerDependency();
        }
    }
}

using Autofac;
using CRM.Domain;
using Domain.Abstracions.Services;

namespace CRM.WebApi.DI.Autofac.Modules
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(DomainAssemblyMarker).Assembly)
                .AssignableTo<IDomainService>()
                .AsImplementedInterfaces()
                .InstancePerDependency();
        }
    }
}

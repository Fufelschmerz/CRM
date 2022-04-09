using CRM.Application;
using CRM.Application.Authorization;
using CRM.Application.Infrastructure.Authentication;
using CRM.Domain.Users.Objects.Entities;
using Microsoft.AspNetCore.Authorization;

namespace CRM.WebApi.DI.Autofac.Modules
{
    using Application.Infrastructure.Authorization.Providers;
    using global::Autofac;

    public class AuthorizationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<IdClaimBasedUserProvider<User>>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<IdClaimBasedCookieAsyncAuthenticationService<User>>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .WithParameter("scheme", Schemes.UserScheme);


            builder.RegisterAssemblyTypes(typeof(ApplicationAssemblyMarker).Assembly)
                .AssignableTo<IAuthorizationHandler>()
                .As<IAuthorizationHandler>()
                .InstancePerLifetimeScope();
        }
    }
}
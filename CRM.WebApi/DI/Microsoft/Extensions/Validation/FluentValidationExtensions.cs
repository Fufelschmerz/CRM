namespace CRM.WebApi.DI.Microsoft.Extensions.Validation
{
    using Application;
    using FluentValidation.AspNetCore;
    using global::Microsoft.Extensions.DependencyInjection;

    public static class FluentValidationExtensions
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidation
                (options => options.RegisterValidatorsFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));
            return services;
        }
    }
}

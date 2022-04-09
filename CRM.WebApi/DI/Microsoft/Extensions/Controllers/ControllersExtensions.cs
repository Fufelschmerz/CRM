namespace CRM.WebApi.DI.Microsoft.Extensions.Controllers
{
    using global::Microsoft.Extensions.DependencyInjection;

    public static class ControllersExtensions
    {
        public static IServiceCollection ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers();

            return services;
        }
    }
}

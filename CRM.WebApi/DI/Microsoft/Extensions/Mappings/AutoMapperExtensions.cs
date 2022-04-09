using CRM.Application;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.WebApi.DI.Microsoft.Extensions.Mappings
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationAssemblyMarker).Assembly);

            return services;
        }
    }
}

namespace CRM.WebApi
{
    using Autofac;
    using Autofac.Extensions.ConfiguredModules;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using CRM.WebApi.DI.Microsoft.Extensions.Swagger;
    using CRM.WebApi.DI.Microsoft.Extensions.Mappings;
    using CRM.WebApi.DI.Microsoft.Extensions.Validation;
    using CRM.WebApi.DI.Microsoft.Extensions.Authorization;
    using CRM.WebApi.DI.Microsoft.Extensions.Controllers;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services
                .AddSwagger();

            ConfigureServices(services);
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.ConfigureControllers();

            services.ConfigureAuthentication();

            services.ConfigureAuthorization();

            services.AddAutoMapper();

            services.AddFluentValidation();

        }

        public void ConfigureDevelopment(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder
                .UseDeveloperExceptionPage()
                .UseSwagger();

            Configure(applicationBuilder);
        }

        public void ConfigureContainer(ContainerBuilder  containerBuilder)
        {
            containerBuilder.RegisterConfiguredModulesFromCurrentAssembly(Configuration);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "/{controller}/{action}");
            });
        }
    }
}

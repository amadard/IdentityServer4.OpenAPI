using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer4.OpenAPI
{
  public static class ConfigureServicesExtensions
    {
        public static IServiceCollection AddOpenAPIResponseGenerator(this IServiceCollection services)
        {
            services.AddSingleton<IOpenAPIDocumentGenerator, OpenAPIDocumentGenerator>();

            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace IdentityServer4.OpenAPI
{
	public static class ConfigureServicesExtensions
	{
		public static IServiceCollection AddOpenAPIResponseGenerator(this IServiceCollection services, string issuerUri)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo()
				{
					Version = "v1",
					Title = "IdentityServer4",
					Description = "IdentityServer4 is an OpenID Connect and OAuth 2.0 framework for ASP.NET Core.",
				});
				c.DocumentFilter<IdentityServerDocumentFilter>(issuerUri);
			});

			return services;
		}
	}
}

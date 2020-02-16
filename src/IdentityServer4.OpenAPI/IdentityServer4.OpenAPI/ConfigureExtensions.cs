using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace IdentityServer4.OpenAPI
{
    public static class ConfigureExtensions
    {
        public static IApplicationBuilder UseOpenAPIGenerator(this IApplicationBuilder builder)
        {
            var routeBuilder = new RouteBuilder(builder);

            routeBuilder.MapMiddlewareGet("/swagger/v1/swagger.json", appBuilder =>
            {
                appBuilder.UseMiddleware<OpenAPIMiddleware>();
            });

            var routes = routeBuilder.Build();
            return builder.UseRouter(routes);
        }
    }
}

using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Writers;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace IdentityServer4.OpenAPI
{
    public class OpenAPIMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOpenAPIDocumentGenerator _responseGenerator;

        public OpenAPIMiddleware(RequestDelegate next, IOpenAPIDocumentGenerator Generator)
        {
            _next = next;
            _responseGenerator = Generator;
        }

        public async Task Invoke(HttpContext context)
        {           
            if (_responseGenerator == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync($"{nameof(IOpenAPIDocumentGenerator)} not registered");
            }
            else
            {
                var issuerUri = context.GetIdentityServerIssuerUri();
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                var document = await _responseGenerator.CreateOpenAPIDocAsync(issuerUri);

                using (var outputString = new StringWriter())
                {
                    var writer = new OpenApiJsonWriter(outputString);
                    document.SerializeAsV3(writer);
                    await context.Response.WriteAsync(outputString.ToString());
                }
            }
            return;
        }
    }
}

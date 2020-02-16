﻿using Microsoft.OpenApi.Models;
using System.Threading.Tasks;

namespace IdentityServer4.OpenAPI
{
    /// <summary>
    /// Interface for OpenAPIDocument generation
    /// </summary>
    public interface IOpenAPIDocumentGenerator
    {
        /// <summary>
        /// Creates an OpenApiDocument
        /// </summary>
        /// <param name="issuerUri">Base URI for IdentityServer</param>
        Task<OpenApiDocument> CreateOpenAPIDocAsync(string issuerUri);
    }
}

using AnimeApp.Application.Common.Constants;
using AnimeApp.Domain.Interfaces;
using System.Net;

namespace AnimeApp.Presentation.Middlewares
{
    public class ApiKeyValidatorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IApiKeyValidator _apiKeyValidation;

        public ApiKeyValidatorMiddleware(RequestDelegate next, IApiKeyValidator apiKeyValidation)
        {
            _next = next;
            _apiKeyValidation = apiKeyValidation;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var userApiKey = context.Request.Headers[ApiConstants.ApiKeyHeader];
            if (string.IsNullOrEmpty(userApiKey))
            {
                throw new UnauthorizedAccessException("API key is missing.");
            }

            if (!_apiKeyValidation.IsValidApiKey(userApiKey))
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            await _next(context);
        }
        
    }
}

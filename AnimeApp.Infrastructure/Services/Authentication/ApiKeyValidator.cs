using AnimeApp.Application.Common.Constants;
using AnimeApp.Domain.Interfaces;
using Microsoft.Extensions.Configuration;


namespace AnimeApp.Infrastructure.Services.Authentication
{
    public class ApiKeyValidator : IApiKeyValidator
    {
        private readonly IConfiguration _configuration;

        public ApiKeyValidator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool IsValidApiKey(string userApiKey)
        {
            if (string.IsNullOrEmpty(userApiKey))
            {
                return false;
            }

            var apiKey = _configuration.GetValue<string>(ApiConstants.ApiKeyName);

            if (apiKey is null || apiKey != userApiKey)
            {
                return false;
            }

            return true;
        }
    }
}

using System.Net.Http.Headers;
using UniiivMWebAsembly.Services;

namespace UniiivMWebAsembly.Configurations
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly TokenService _tokenService;

        public AuthTokenHandler(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _tokenService.GetTokenAsync();
            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}

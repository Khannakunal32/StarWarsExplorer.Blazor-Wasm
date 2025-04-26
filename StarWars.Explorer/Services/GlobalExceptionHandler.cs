using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars.Explorer.Infrastructure
{
    public class GlobalExceptionHandler : DelegatingHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                // Forward the request to the inner handler
                return await base.SendAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                // Log the exception with detailed information
                _logger.LogError(ex, "HTTP request failed: {Method} {Url}",
                    request.Method, request.RequestUri);

                // For more specific exception types, you could add special handling here
                if (ex is NotImplementedException)
                {
                    _logger.LogError("Method not implemented: This is a development error");
                }
                else if (ex is HttpRequestException)
                {
                    _logger.LogError("API communication error: Check network or API status");
                }

                // Rethrow to let Blazor's error boundary handle it
                throw;
            }
        }
    }
}
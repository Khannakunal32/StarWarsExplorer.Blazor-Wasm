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
                return await base.SendAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "HTTP request failed: {Method} {Url}",
                    request.Method, request.RequestUri);

                if (ex is NotImplementedException)
                {
                    _logger.LogError("Method not implemented: This is a development error");
                }
                else if (ex is HttpRequestException)
                {
                    _logger.LogError("API communication error: Check network or API status");
                }

                throw;
            }
        }
    }
}
namespace Razor.UI.Infrastructure
{
    public class HttpClientRequestIdDelegatingHandler: DelegatingHandler
    {
        private const string CORRELATION_TOKEN = "Correlation-Token";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Post || request.Method == HttpMethod.Put)
            {
                if (!request.Headers.Contains(CORRELATION_TOKEN))
                {
                    request.Headers.Add(CORRELATION_TOKEN, Guid.NewGuid().ToString());
                }
            }

            return await base.SendAsync(request, cancellationToken);
        }      
    }
}

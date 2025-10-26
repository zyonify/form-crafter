using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Logging;

namespace FormMaker.Api.Middleware;

/// <summary>
/// Middleware to add CORS headers to all HTTP responses
/// </summary>
public class CorsMiddleware : IFunctionsWorkerMiddleware
{
    private readonly ILogger<CorsMiddleware> _logger;

    public CorsMiddleware(ILogger<CorsMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        _logger.LogInformation("CORS Middleware: Processing request");

        // Get the HTTP request data
        var requestData = await context.GetHttpRequestDataAsync();

        if (requestData != null)
        {
            _logger.LogInformation("CORS Middleware: Request method = {Method}, Path = {Path}",
                requestData.Method, requestData.Url.PathAndQuery);
        }

        // Continue with the function execution
        await next(context);

        // Add CORS headers to the response
        if (requestData != null)
        {
            var invocationResult = context.GetInvocationResult();

            if (invocationResult?.Value is HttpResponseData responseData)
            {
                _logger.LogInformation("CORS Middleware: Adding CORS headers to response");
                AddCorsHeaders(responseData, requestData);
            }
            else
            {
                _logger.LogWarning("CORS Middleware: No HttpResponseData found in invocation result");
            }
        }
    }

    private void AddCorsHeaders(HttpResponseData response, HttpRequestData request)
    {
        try
        {
            // Get the origin from the request
            var origin = request.Headers.TryGetValues("Origin", out var origins)
                ? origins.FirstOrDefault()
                : null;

            _logger.LogInformation("CORS Middleware: Request origin = {Origin}", origin ?? "none");

            // If no origin, allow all (for same-origin requests)
            if (string.IsNullOrEmpty(origin))
            {
                origin = "*";
            }

            // Add CORS headers - try/catch each one in case headers already exist
            TryAddHeader(response, "Access-Control-Allow-Origin", origin);
            TryAddHeader(response, "Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            TryAddHeader(response, "Access-Control-Allow-Headers", "Content-Type, Authorization, Accept");

            // Only add credentials header if not using wildcard origin
            if (origin != "*")
            {
                TryAddHeader(response, "Access-Control-Allow-Credentials", "true");
            }

            TryAddHeader(response, "Access-Control-Max-Age", "86400");

            _logger.LogInformation("CORS Middleware: Successfully added CORS headers");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "CORS Middleware: Error adding CORS headers");
        }
    }

    private void TryAddHeader(HttpResponseData response, string name, string value)
    {
        try
        {
            if (!response.Headers.Contains(name))
            {
                response.Headers.Add(name, value);
                _logger.LogDebug("CORS Middleware: Added header {Name} = {Value}", name, value);
            }
            else
            {
                _logger.LogDebug("CORS Middleware: Header {Name} already exists", name);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "CORS Middleware: Failed to add header {Name}", name);
        }
    }
}

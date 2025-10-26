using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Middleware;

namespace FormMaker.Api.Middleware;

/// <summary>
/// Middleware to add CORS headers to all HTTP responses
/// </summary>
public class CorsMiddleware : IFunctionsWorkerMiddleware
{
    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        // Continue with the function execution first
        await next(context);

        // Get the HTTP request and response data
        var requestData = await context.GetHttpRequestDataAsync();

        if (requestData != null)
        {
            var invocationResult = context.GetInvocationResult();

            // Add CORS headers to any HTTP response
            if (invocationResult?.Value is HttpResponseData responseData)
            {
                AddCorsHeaders(responseData, requestData);
            }
        }
    }

    private static void AddCorsHeaders(HttpResponseData response, HttpRequestData request)
    {
        // Get the origin from the request
        var origin = request.Headers.TryGetValues("Origin", out var origins)
            ? origins.FirstOrDefault()
            : "*";

        // Add CORS headers
        response.Headers.Add("Access-Control-Allow-Origin", origin);
        response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
        response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization, Accept");
        response.Headers.Add("Access-Control-Allow-Credentials", "true");
        response.Headers.Add("Access-Control-Max-Age", "86400");
    }
}

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
        // Get the HTTP request data
        var requestData = await context.GetHttpRequestDataAsync();

        if (requestData != null)
        {
            // Handle preflight OPTIONS requests
            if (requestData.Method.Equals("OPTIONS", StringComparison.OrdinalIgnoreCase))
            {
                var response = requestData.CreateResponse(System.Net.HttpStatusCode.OK);
                AddCorsHeaders(response, requestData);

                var invocationResult = context.GetInvocationResult();
                invocationResult.Value = response;
                return;
            }
        }

        // Continue with the function execution
        await next(context);

        // Add CORS headers to the response
        var httpReqData = await context.GetHttpRequestDataAsync();
        if (httpReqData != null)
        {
            var invocationResult = context.GetInvocationResult();
            if (invocationResult.Value is HttpResponseData responseData)
            {
                AddCorsHeaders(responseData, httpReqData);
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

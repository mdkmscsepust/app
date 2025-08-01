using System.Text;

namespace App.API.Helpers;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;
    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var body = context.Request.Body;
        _logger.LogInformation("Hello request {Method} {Path} {QueryString}",
        context.Request.Method,
        context.Request.Path,
        context.Request.QueryString);
        await LogRequestBodyAsync(context);

        var originalBodyStream = context.Response.Body;
        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;
        await _next.Invoke(context);
        _logger.LogInformation("response {statusCode}", context.Response.StatusCode);
        context.Response.Body.Seek(0, SeekOrigin.Begin);
        using var reader = new StreamReader(context.Response.Body);
        var bodyRes = await reader.ReadToEndAsync();
        _logger.LogInformation("Response Body: {Body}", bodyRes);
        context.Response.Body.Seek(0, SeekOrigin.Begin);

        // Copy response back to original stream
        await responseBody.CopyToAsync(originalBodyStream);
    }

    private async Task LogRequestBodyAsync(HttpContext context)
    {
        context.Request.EnableBuffering();
        using var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true);
        var body = await reader.ReadToEndAsync();
        context.Request.Body.Position = 0;
        _logger.LogInformation("Request Body: {Body}", body);
    }

    private async Task LogResponseBodyAsync(HttpContext context)
    {
        //context.Response.EnableBuffering();
        using var reader = new StreamReader(context.Response.Body);
        var body = await reader.ReadToEndAsync();
        _logger.LogInformation("Response Body: {Body}", body);
    }
}
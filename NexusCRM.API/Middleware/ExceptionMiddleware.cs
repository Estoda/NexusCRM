using NexusCRM.API.Common;
using System.Net;
using System.Text.Json;

namespace NexusCRM.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var response = ApiResponse<string>.Fail(ex.Message);
        var json = JsonSerializer.Serialize(response);

        return context.Response.WriteAsync(json);
    }
}

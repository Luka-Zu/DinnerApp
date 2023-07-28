using System.Net;
using System.Text.Json;

namespace DinnerApp.Api.Middleware;
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Exception ex){
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var Code = HttpStatusCode.InternalServerError;
        var Result = JsonSerializer.Serialize(new { error = "An error occured while proccesing your request" });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)Code;

        return context.Response.WriteAsync(Result);
    }
}


using System.Text.Json;
using UsersApi.Results.Implementations;

namespace UsersApi.MiddleWare;

public sealed class GlobalExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<GlobalExceptionHandlingMiddleware> log)
{
    public async Task InvokeAsync(HttpContext ctx)
    {
        try
        {
            await next(ctx);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(ctx, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext ctx, Exception exception)
    {
        var (status, message) = exception switch
        {
            ArgumentException _ => (StatusCodes.Status400BadRequest, exception.Message),
            KeyNotFoundException _ => (StatusCodes.Status404NotFound, exception.Message),
            _ => (StatusCodes.Status500InternalServerError, exception.Message)
        };

        log.LogError(exception, "Exception: {Message}", exception.Message);

        var error = new ErrorOperationResult(message);

        ctx.Response.ContentType = "application/json";
        ctx.Response.StatusCode = status;

        await ctx.Response.WriteAsync(JsonSerializer.Serialize(error));
    }
}
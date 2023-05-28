using System.Net;
using Domain.Exceptions;

namespace API.MiddleWare;

internal sealed class ErrorMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (DomainException e)
        {
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(new
            {
                // TODO: Прокидывать нормальное сообщение
                Message = "Бро, кринжуешь"
            }.ToString() ?? string.Empty);

        }
        catch (Exception e)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Console.WriteLine(e);
            await context.Response.WriteAsync(new
            {
                Message = e.Message
            }.ToString() ?? string.Empty);
        }
    }
}
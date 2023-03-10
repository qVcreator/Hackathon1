using System.Net;
using UwULearn.Bussines.Exceptions;
using UwULearn2.API.Models;

namespace UwULearn2.API.CustomExceptionMiddleWare;

public class ExceptionMiddleWare
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleWare(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch(NotFoundException error)
        {
            await HandleExceptionAsync(httpContext, HttpStatusCode.BadRequest, error.Message);
        }
        catch (NotEnoughEnergyException error)
        {
            await HandleExceptionAsync(httpContext, HttpStatusCode.BadRequest, error.Message);
        }
        catch (Exception error)
        {
            await HandleExceptionAsync(httpContext, HttpStatusCode.InternalServerError, error.Message);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            Message = message
        }.ToString());
    }
}

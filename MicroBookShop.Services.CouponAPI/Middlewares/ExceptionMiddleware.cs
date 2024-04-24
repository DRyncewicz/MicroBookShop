using MicroBookShop.Services.CouponAPI.Domain.Errors;
using System.Net;

namespace MicroBookShop.Services.CouponAPI.Middlewares;

public class ExceptionMiddleware(ILogger<ExceptionMiddleware> logger) : IMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context,
                                  RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context,
                                            Exception exception)
    {
        context.Response.ContentType = "application/json";

        ErrorDetails errorDetails = exception switch
        {
            _ => CreateErrorResponseWithLog(context, HttpStatusCode.InternalServerError, "Internal server error", exception)
        };

        await context.Response.WriteAsync(errorDetails.ToString(), context.RequestAborted);
    }

    private static ErrorDetails CreateErrorResponse(HttpContext context,
                                                    HttpStatusCode statusCode,
                                                    string message)
    {
        context.Response.StatusCode = (int)statusCode;

        return new ErrorDetails
        {
            StatusCode = context.Response.StatusCode,
            Message = message
        };
    }

    private ErrorDetails CreateErrorResponseWithLog(HttpContext context,
                                                    HttpStatusCode statusCode,
                                                    string message,
                                                    Exception exception)
    {
        _logger.LogError(exception, "Exception caught by global exception middleware");

        return CreateErrorResponse(context, statusCode, message);
    }
}
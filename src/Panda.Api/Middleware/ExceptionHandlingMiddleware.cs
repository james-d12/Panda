using Panda.Core.Common.Exceptions;
using System.Text.Json;

namespace Panda.Api.Middleware;

internal sealed class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);

            await HandleExceptionAsync(context, e);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        int statusCode = GetStatusCode(exception);

        var response = new { status = statusCode, detail = exception.Message, errors = GetErrors(exception) };

        httpContext.Response.ContentType = "application/json";

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
    }


    private static int GetStatusCode(Exception exception)
    {
        if (exception is BaseException baseException)
        {
            return (int)baseException.StatusCode;
        }

        return 500;
    }

    private static IReadOnlyDictionary<string, string[]> GetErrors(Exception exception)
    {
        IReadOnlyDictionary<string, string[]> errors = new Dictionary<string, string[]>();

        if (exception is ValidationBehaviourException validationException)
        {
            errors = validationException.ErrorsDictionary;
        }

        return errors;
    }
}
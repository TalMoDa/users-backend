using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace UsersApi.MiddleWares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var response = context.Response;

            response.ContentType = "application/json";
            response.StatusCode = StatusCodes.Status500InternalServerError;

            await response.WriteAsync(new
            {
                message = ex.Message,
                statusCode = response.StatusCode
            }.ToString() ?? string.Empty);
        }
    }

}
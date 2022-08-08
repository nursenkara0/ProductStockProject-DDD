using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Text.Json;
using System.Net;

namespace Infrastructure.Attributes
{
    public class CustomExceptionMiddleware
    {

        private readonly RequestDelegate _next;
        //private readonly ILoggerService _logger;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
            //_logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = "{Request} HTTP " + httpContext.Request.Method + " - " + httpContext.Request.Path;
                //_logger.Write(message);
                await _next(httpContext);
                watch.Stop();
                message = "{Request} HTTP " + httpContext.Request.Method + " - " + httpContext.Request.Path + " responded" + httpContext.Response.StatusCode + " in : " + watch.ElapsedMilliseconds;
                //_logger.Write(message);
            }
            catch (System.Exception ex)
            {

                watch.Stop();
                await HandleException(httpContext, ex, watch);
            }

        }

        private Task HandleException(HttpContext httpContext, Exception ex, Stopwatch watch)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var message = "{Error} HTTP " + httpContext.Request.Method + " - " + httpContext.Response.StatusCode + "Error MEssage" + ex.Message + " in " + watch.ElapsedTicks;
            //_logger.Write(message);


            var result = JsonSerializer.Serialize(new { error = ex.Message });



            //JsonConverter.SerializeObject(new { error = ex.Message }, Formatting.None);

            return httpContext.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionMiddlewareExtension
    {

        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }

}

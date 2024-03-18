using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Watch_Store_Management_Web_API.BusinessLogicLayer.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlarMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlarMiddleware> logger;

        public ExceptionHandlarMiddleware(RequestDelegate next, ILogger<ExceptionHandlarMiddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext); //This can call either next middleware in the pipeline or the controller
            }
            catch (Exception exception)
            {
                // Log the Exception
                logger.LogInformation($"Exception Occurred => {exception}");
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsJsonAsync(new
                {
                    Error = exception.Message,
                    Status = 500,
                    Success = false
                });
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlarMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlarMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlarMiddleware>();
        }
    }
}

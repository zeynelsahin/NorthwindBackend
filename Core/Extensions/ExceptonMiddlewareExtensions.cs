using Microsoft.AspNetCore.Builder;

namespace Core.Extensions
{
    public static class ExceptonMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
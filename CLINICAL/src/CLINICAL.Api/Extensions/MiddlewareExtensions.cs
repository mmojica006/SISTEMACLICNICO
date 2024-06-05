using CLINICAL.Api.Extensions.Middleware;

namespace CLINICAL.Api.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder AddMidleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ValidationMiddleware>();
        }
    }
}

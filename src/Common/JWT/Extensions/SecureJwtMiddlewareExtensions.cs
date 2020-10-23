using Hlopov.Common.JWT.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Hlopov.Common.JWT.Extensions
{
    public static class SecureJwtMiddlewareExtensions
    {
        public static IApplicationBuilder UseSecureJwt(this IApplicationBuilder builder) => builder.UseMiddleware<SecureJwtMiddleware>();
    }
}
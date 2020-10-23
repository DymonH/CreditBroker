using System.Security.Claims;

namespace Hlopov.Common.JWT.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Login(this ClaimsPrincipal principal)
        {
            var claimn = principal.FindFirst(ClaimTypes.Sid);
            return claimn?.Value;
        }
    }
}
using System.Security.Claims;
using Hlopov.Common.JWT.Models;
using Hlopov.CreditBroker.Identification.Core.Entities;

namespace Hlopov.Common.JWT.Interfaces
{
    public interface IJwtTokenHandler
    {
        JwtTokenResult GenerateToken(ArmUser user);

        ClaimsPrincipal GetPrincipalFromToken(string token);
    }
}
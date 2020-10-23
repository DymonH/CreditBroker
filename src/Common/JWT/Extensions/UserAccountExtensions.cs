using System;
using System.Collections.Generic;
using System.Security.Claims;
using Hlopov.CreditBroker.Identification.Core.Entities;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Hlopov.Common.JWT.Extensions
{
    public static class UserAccountExtensions
    {
        public static ClaimsIdentity BuildClaims<T>(this T user)
            where T : ArmUser
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Sid, user.Login),
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.TimeOfDay.Ticks.ToString(), ClaimValueTypes.Integer64)
            };

            return new ClaimsIdentity(claims, "token");
        }
    }
}
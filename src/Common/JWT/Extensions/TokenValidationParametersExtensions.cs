using System;
using Microsoft.IdentityModel.Tokens;

namespace Hlopov.Common.JWT.Extensions
{
    public static class TokenValidationParametersExtensions
    {
        internal static TokenValidationParameters ToTokenValidationParams(this JwtOptions tokenOptions) =>
            new TokenValidationParameters
            {
                ClockSkew = TimeSpan.Zero,
                ValidateAudience = true,
                ValidAudience = tokenOptions.Audience,
                ValidateIssuer = true,
                ValidIssuer = tokenOptions.Issuer,
                IssuerSigningKey = tokenOptions.SigningKey,
                ValidateIssuerSigningKey = true,
                RequireExpirationTime = true,
                ValidateLifetime = true
            };
    }
}
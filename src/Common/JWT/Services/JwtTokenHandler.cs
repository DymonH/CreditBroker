using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Hlopov.Common.JWT.Extensions;
using Hlopov.Common.JWT.Interfaces;
using Hlopov.Common.JWT.Models;
using Hlopov.CreditBroker.Identification.Core.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Hlopov.Common.JWT.Services
{
    public sealed class JwtTokenHandler : IJwtTokenHandler
    {
        private readonly JwtOptions _tokenOptions;

        public JwtTokenHandler(JwtOptions tokenOptions)
        {
            _tokenOptions = tokenOptions ??
                            throw new ArgumentNullException(
                                $"An instance of valid {nameof(JwtOptions)} must be passed in order to generate a JWT!");
        }

        public JwtTokenResult GenerateToken(ArmUser user)
        {
            var expiration = TimeSpan.FromMinutes(_tokenOptions.TokenExpiryInMinutes);
            var claimsIdentity = user.BuildClaims();

            var jwt = new JwtSecurityToken(
                _tokenOptions.Issuer,
                _tokenOptions.Audience,
                claimsIdentity.Claims,
                DateTime.UtcNow,
                DateTime.UtcNow.Add(expiration),
                new SigningCredentials(_tokenOptions.SigningKey, SecurityAlgorithms.HmacSha256));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtTokenResult
            {
                Token = accessToken,
                Expires = expiration
            };
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _tokenOptions.SigningKey,
                ValidateLifetime = true
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                return null;

            return principal;
        }
    }
}
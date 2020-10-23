using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Hlopov.Common.JWT
{
    public sealed class JwtOptions
    {
        public JwtOptions(string issuer, string audience, string rawSigningKey, int tokenExpiryInMinutes = 5)
            : this(issuer, audience, new SymmetricSecurityKey(Encoding.ASCII.GetBytes(rawSigningKey)), tokenExpiryInMinutes)
        {
        }
        
        internal JwtOptions(string issuer, string audience, SecurityKey signingKey, int tokenExpiryInMinutes = 5)
        {
            if (string.IsNullOrWhiteSpace(audience))
                throw new ArgumentNullException(
                    $"{nameof(Audience)} is required in order to generate a JWT!");

            if (string.IsNullOrWhiteSpace(issuer))
                throw new ArgumentNullException(
                    $"{nameof(Issuer)} is required in order to generate a JWT!");

            Audience = audience;
            Issuer = issuer;
            SigningKey = signingKey ??
                         throw new ArgumentNullException(
                             $"{nameof(SigningKey)} is required in order to generate a JWT!");

            TokenExpiryInMinutes = tokenExpiryInMinutes;
        }

        public SecurityKey SigningKey { get; }

        public string Issuer { get; }

        public string Audience { get; }

        public int TokenExpiryInMinutes { get; }
    }
}
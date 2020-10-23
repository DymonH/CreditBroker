namespace Hlopov.CreditBroker.Identification.Core.Configuration
{
    public class IdentificationOptions
    {
        public const string Section = "Identification";

        public string Audience { get; set; }
        
        public string Issuer { get; set; }
        
        public string Secret { get; set; }

        public string TokenCookieName { get; set; }

        public int TokenLifetimeMinutes { get; set; }

        public string RefreshTokenCookieName { get; set; }

        public int RefreshTokenLifetimeMinutes { get; set; }
    }
}
using System;

namespace Hlopov.CreditBroker.Identification.Application.Responses
{
    public class IdentificationResponse
    {
        public string Login { get; set; }

        public string Name { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpireDate { get; set; }
    }
}
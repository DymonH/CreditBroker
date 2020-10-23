using Hlopov.CreditBroker.Identification.Application.Responses;
using MediatR;

namespace Hlopov.CreditBroker.Identification.Application.Commands
{
    public class IdentificationCommand : IRequest<IdentificationResponse>
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public string Device { get; set; }
    }
}
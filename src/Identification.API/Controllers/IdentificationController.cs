using System;
using System.Net;
using System.Threading.Tasks;
using Hlopov.CreditBroker.Identification.Application.Commands;
using Hlopov.CreditBroker.Identification.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hlopov.CreditBroker.Identification.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentificationController : ControllerBase
    {
        private readonly ILogger<IdentificationController> _logger;
        private readonly IMediator _mediator;

        public IdentificationController(IMediator mediator, ILogger<IdentificationController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [ProducesResponseType(typeof(IdentificationResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Identify([FromBody] IdentificationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
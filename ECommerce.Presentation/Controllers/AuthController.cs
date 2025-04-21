using ECommerce.Applicatoin.Features.Auth.Command.Register;
using ECommerce.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/UserManagement/[controller]")]
    public sealed class AuthController : ApiController
    {
        private readonly IMediator _mediator;

        public AuthController(  IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }
    }
}

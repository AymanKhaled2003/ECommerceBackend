using ECommerce.Application.Features.Cart.Command.AddToCart;
using ECommerce.Application.Features.Cart.Query.GetCart;
using ECommerce.Applicatoin.Features.Cart.Command.RemoveFromCart;
using ECommerce.Applicatoin.Features.Cart.Query.GetCart;
using ECommerce.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Presentation.Controllers
{
    [Route("api/CartManagement/[controller]")]
    public sealed class CartController : ApiController
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-to-cart")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        [HttpGet("GetCartByUserId")]
        public async Task<IActionResult> GetCartByUserId([FromQuery] GetCartQuery query)
        {
            var result = await _mediator.Send(query);
            return HandleResult(result);
        }

        [HttpDelete("remove-from-cart")]
        public async Task<IActionResult> RemoveFromCart([FromBody] RemoveFromCartCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }
    }

}

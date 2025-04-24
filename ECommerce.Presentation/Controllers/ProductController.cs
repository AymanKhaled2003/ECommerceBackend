
using ECommerce.Application.Features.Products.Command.Add;
using ECommerce.Application.Features.Products.Command.DeleteProduct;
using ECommerce.Application.Features.Products.Command.Edit;
using ECommerce.Application.Features.Products.Query.GetAllProduct;
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
    [Route("api/ProductManagement/[controller]")]
    public sealed class ProductController : ApiController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditProduct([FromBody] EditProductCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct([FromQuery] GetAllProductsQuery query)
        {
            var result = await _mediator.Send(query);
            return HandleResult(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand delete)
        {
            var result = await _mediator.Send(delete);
            return HandleResult(result);
        }
    }

}

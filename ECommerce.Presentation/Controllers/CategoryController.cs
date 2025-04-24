
using ECommerce.Application.Features.Categories.Command.AddCategory;
using ECommerce.Application.Features.Categories.Command.DeleteCategory;
using ECommerce.Application.Features.Categories.Command.EditCategory;
using ECommerce.Application.Features.Categories.Query.GetAllCategories;
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
    [Route("api/CategoryManagement/[controller]")]
    public sealed class CategoryController : ApiController
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("addCategory")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        [HttpPut("EditCategory")]
        public async Task<IActionResult> EditCategory([FromBody] EditCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory([FromQuery] GetAllCategoriesQuery query)
        {
            var result = await _mediator.Send(query);
            return HandleResult(result);
        }


        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommand delete)
        {
            var result = await _mediator.Send(delete);
            return HandleResult(result);
        }
    }

}

using eCommerce.Application.DTOs.CategoryDtos;
using eCommerce.Application.Features.Commands;
using eCommerce.Application.Features.Queries;
using eCommerce.Application.Features.Queries.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace eCommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(IMediator mediator, ILogger<CategoryController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Creates new category")]
        public async Task<ActionResult<int>> Post(CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get specific category with given Id")]
        public async Task<ActionResult> Get(int id)
        {
            var query = new GetSingleItemQuery<CategoryWithProductsDto> { Id = id };
            var result = await _mediator.Send(query);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove specific category with given Id")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new RemoveCategoryCommand { Id = id };
            if (await _mediator.Send(command))
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPatch]
        [SwaggerOperation(Summary = "Update specific category with given Id")]
        public async Task<ActionResult> Update(UpdateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all categories")]
        public async Task<ActionResult> Get()
        {
            var result = await _mediator.Send(new GetCategoriesQuery());
            if (result is null)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
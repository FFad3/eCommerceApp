using eCommerce.Application.Features.Commands;
using eCommerce.Application.Features.Queries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

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
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get specific category with given Id")]
        public async Task<ActionResult> Get(int id)
        {
            var query = new GetCategoryQuery { id = id };
            var result = await _mediator.Send(query);
            if (result is null)
            {
                return NoContent();
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
        public async Task<ActionResult> Update()
        {
            return Ok(new NotImplementedException("WIP"));
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get paginated result")]
        public async Task<ActionResult> Get([FromQuery] GetCategoryPageQuery query)
        {
            var result = await _mediator.Send(query);
            if (result is null)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
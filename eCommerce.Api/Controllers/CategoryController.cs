using eCommerce.Application.Features.Commands;
using eCommerce.Application.Features.Queries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

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
        public async Task<ActionResult<int>> Post([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetCategoryQuery { id = id });
            if (result is null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet]
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
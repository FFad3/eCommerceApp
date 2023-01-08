using eCommerce.Application.DTOs.ProductDtos;
using eCommerce.Application.Features.Commands.ProductCommands;
using eCommerce.Application.Features.Queries.Common;
using eCommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace eCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CategoryController> _logger;

        public ProductController(IMediator mediator, ILogger<CategoryController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adds new product")]
        public async Task<ActionResult> Post(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get produucts page")]
        public async Task<ActionResult> Get([FromQuery] GetPaginationResult<ProductDto> query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
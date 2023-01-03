using AutoMapper;
using eCommerce.Application.Contracts.Persistence.Repositories;
using eCommerce.Application.DTOs.CategoryDtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerce.Application.Features.Queries
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryWithProductsDto?>
    {
        private readonly ICategoryRepository _repo;
        private readonly ILogger<GetCategoryQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(ICategoryRepository repo, ILogger<GetCategoryQueryHandler> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CategoryWithProductsDto?> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repo.GetCategoryWithProductsAsync(x => x.Id == request.id, cancellationToken);
            var result = _mapper.Map<CategoryWithProductsDto>(entity);
            _logger.LogInformation("Get Category with Products {@payload}", result);
            return result;
        }
    }
}
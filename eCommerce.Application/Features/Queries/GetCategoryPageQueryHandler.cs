using AutoMapper;
using AutoMapper.QueryableExtensions;
using eCommerce.Application.Common.Mappings;
using eCommerce.Application.Contracts.Persistence.Repositories;
using eCommerce.Application.DTOs.CategoryDtos;
using eCommerce.Application.DTOs.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerce.Application.Features.Queries
{
    public class GetCategoryPageQueryHandler : IRequestHandler<GetCategoryPageQuery, PaginatedList<CategoryDto>>
    {
        private readonly ICategoryRepository _repo;
        private readonly ILogger<GetCategoryPageQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetCategoryPageQueryHandler(ICategoryRepository repo, ILogger<GetCategoryPageQueryHandler> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CategoryDto>> Handle(GetCategoryPageQuery request, CancellationToken cancellationToken)
        {
            var result = await _repo.AsIQuerable()
                .OrderBy(x => x.Id)
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.Page, request.Size, cancellationToken);
            _logger.LogInformation("Get {@itemsCount} Categories from {@page}/{@totalPages} page", result.Items.Count(), result.PageNumber, result.TotalPages);
            return result;
        }
    }
}
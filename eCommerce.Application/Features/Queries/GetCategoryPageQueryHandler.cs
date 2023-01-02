using AutoMapper;
using AutoMapper.QueryableExtensions;
using eCommerce.Application.Common.Extensions;
using eCommerce.Application.Common.Mappings;
using eCommerce.Application.Contracts.Persistence.Repositories;
using eCommerce.Application.DTOs.CategoryDtos;
using eCommerce.Application.DTOs.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eCommerce.Application.Features.Queries
{
    public class GetCategoryPageQueryHandler : IRequestHandler<GetPaginationResult<CategoryDto>, PaginatedList<CategoryDto>>
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

        public async Task<PaginatedList<CategoryDto>> Handle(GetPaginationResult<CategoryDto> request, CancellationToken cancellationToken)
        {
            var result = await _repo.AsIQuerable()
                .Include(x => x.Products)
                .ApplySort(request.SortStr)
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.Page, request.Size, cancellationToken);
            _logger.LogInformation("Get {@itemsCount} Categories from {@page}/{@totalPages} page Sorting:{@sorting}", result.Items.Count(), result.PageNumber, result.TotalPages, request.SortStr);
            return result;
        }
    }
}
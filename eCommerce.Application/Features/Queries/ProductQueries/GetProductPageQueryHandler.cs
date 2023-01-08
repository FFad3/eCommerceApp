using AutoMapper;
using AutoMapper.QueryableExtensions;
using eCommerce.Application.Common.Extensions;
using eCommerce.Application.Common.Mappings;
using eCommerce.Application.Contracts.Persistence;
using eCommerce.Application.DTOs.Common;
using eCommerce.Application.DTOs.ProductDtos;
using eCommerce.Application.Features.Queries.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eCommerce.Application.Features.Queries
{
    public class GetProductPageQueryHandler : IRequestHandler<GetPaginationResult<ProductWithCategoryDto>, PaginatedList<ProductWithCategoryDto>>
    {
        private readonly ILogger<GetProductPageQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetProductPageQueryHandler(ILogger<GetProductPageQueryHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedList<ProductWithCategoryDto>> Handle(GetPaginationResult<ProductWithCategoryDto> request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Product.AsIQuerable()
                .ApplySort(request.SortStr)
                .Include(x => x.Category)
                .ProjectTo<ProductWithCategoryDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.Page, request.Size, cancellationToken);
            _logger.LogInformation("Get {@itemsCount} Categories from {@page}/{@totalPages} page", result.Items.Count(), result.PageNumber, result.TotalPages);
            return result;
        }
    }
}
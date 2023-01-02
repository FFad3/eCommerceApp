using AutoMapper;
using eCommerce.Application.Common.Extensions;
using eCommerce.Application.Common.Mappings;
using eCommerce.Application.Contracts.Persistence.Repositories;
using eCommerce.Application.DTOs.Common;
using eCommerce.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerce.Application.Features.Queries
{
    public class GetProductPageQueryHandler : IRequestHandler<GetPaginationResult<Product>, PaginatedList<Product>>
    {
        private readonly ILogger<GetProductPageQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IProductRepository _repo;

        public GetProductPageQueryHandler(ILogger<GetProductPageQueryHandler> logger, IMapper mapper, IProductRepository repo)
        {
            _logger = logger;
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<PaginatedList<Product>> Handle(GetPaginationResult<Product> request, CancellationToken cancellationToken)
        {
            var result = await _repo.AsIQuerable()
                .ApplySort(request.SortStr)
                //.OrderBy(x => x.Id)
                .PaginatedListAsync(request.Page, request.Size, cancellationToken);
            _logger.LogInformation("Get {@itemsCount} Categories from {@page}/{@totalPages} page", result.Items.Count(), result.PageNumber, result.TotalPages);
            return result;
        }
    }
}
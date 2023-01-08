using AutoMapper;
using eCommerce.Application.Contracts.Persistence;
using eCommerce.Application.DTOs.ProductDtos;
using eCommerce.Application.Features.Queries.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eCommerce.Application.Features.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetSingleItemQuery<ProductWithCategoryDto>, ProductWithCategoryDto?>
    {
        private readonly ILogger<GetProductPageQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetProductQueryHandler(ILogger<GetProductPageQueryHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductWithCategoryDto?> Handle(GetSingleItemQuery<ProductWithCategoryDto> request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Product.AsIQuerable()
                .Include(x=>x.Category)
                .Where(x => x.Id == request.Id && !x.IsRemoved)
                .FirstOrDefaultAsync(cancellationToken);

            var result = _mapper.Map<ProductWithCategoryDto>(entity);
            _logger.LogInformation("Get Category with Products {@payload}", result);
            return result;
        }
    }
}
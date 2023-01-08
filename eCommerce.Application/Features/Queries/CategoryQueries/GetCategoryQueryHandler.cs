using AutoMapper;
using eCommerce.Application.Contracts.Persistence;
using eCommerce.Application.DTOs.CategoryDtos;
using eCommerce.Application.Features.Queries.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerce.Application.Features.Queries
{
    public class GetCategoryQueryHandler : IRequestHandler<GetSingleItemQuery<CategoryWithProductsDto>, CategoryWithProductsDto?>
    {
        private readonly ILogger<GetCategoryQueryHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(ILogger<GetCategoryQueryHandler> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryWithProductsDto?> Handle(GetSingleItemQuery<CategoryWithProductsDto> request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Category.GetCategoryWithProductsAsync(x => x.Id == request.Id && !x.IsRemoved, cancellationToken);
            var result = _mapper.Map<CategoryWithProductsDto>(entity);
            _logger.LogInformation("Get Category with Products {@payload}", result);
            return result;
        }
    }
}
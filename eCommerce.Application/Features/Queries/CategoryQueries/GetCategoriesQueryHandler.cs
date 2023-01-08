using AutoMapper;
using eCommerce.Application.Contracts.Persistence;
using eCommerce.Application.DTOs.CategoryDtos;
using eCommerce.Application.Features.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eCommerce.Application.Features.Queries
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly ILogger<UpdateCategoryCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(ILogger<UpdateCategoryCommandHandler> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var items = await _unitOfWork.Category.AsIQuerable()
                .Include(x => x.Products)
                .Where(x => !x.IsRemoved)
                .ToListAsync(cancellationToken);

            var result = _mapper.Map<IEnumerable<CategoryDto>>(items);
            _logger.LogInformation("Get categories list");
            return result;
        }
    }
}
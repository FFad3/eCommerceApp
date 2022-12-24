using AutoMapper.QueryableExtensions;
using eCommerce.Application.Common.Mappings;
using eCommerce.Application.Contracts.Persistence.Repositories;
using eCommerce.Application.DTOs.Common;
using eCommerce.Domain.Entities;
using MediatR;

namespace eCommerce.Application.Features.Queries
{
    public class GetCategoryPageQueryHandler : IRequestHandler<GetCategoryPageQuery, PaginatedList<Category>>
    {
        private readonly ICategoryRepository _repo;

        public GetCategoryPageQueryHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<PaginatedList<Category>> Handle(GetCategoryPageQuery request, CancellationToken cancellationToken)
        {
            var result = await _repo.AsIQuerable()
                .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
            return result;
        }
    }
}
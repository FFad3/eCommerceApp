using eCommerce.Application.DTOs.CategoryDtos;
using eCommerce.Application.DTOs.Common;
using MediatR;

namespace eCommerce.Application.Features.Queries
{
    public class GetCategoryPageQuery : IRequest<PaginatedList<CategoryDto>>
    {
        public int Page { get; set; } = 1;

        public int Size { get; set; } = 20;
        public string? SortStr { get; set; }
    }
}
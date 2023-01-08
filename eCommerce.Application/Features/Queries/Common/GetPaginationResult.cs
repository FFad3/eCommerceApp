using eCommerce.Application.DTOs.CategoryDtos;
using eCommerce.Application.DTOs.Common;
using MediatR;

namespace eCommerce.Application.Features.Queries.Common

{
    public class GetPaginationResult<T> : IRequest<PaginatedList<T>> where T : class
    {
        public int Page { get; set; } = 1;

        public int Size { get; set; } = 20;

        public string? SortStr { get; set; }
    }
}
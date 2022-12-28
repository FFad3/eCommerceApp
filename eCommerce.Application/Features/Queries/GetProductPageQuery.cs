using eCommerce.Application.DTOs.Common;
using eCommerce.Domain.Entities;
using MediatR;

namespace eCommerce.Application.Features.Queries
{
    public class GetProductPageQuery : IRequest<PaginatedList<Product>>
    {
        public int Page { get; set; } = 1;

        public int Size { get; set; } = 20;

        public string? SortStr { get; set; }
    }
}
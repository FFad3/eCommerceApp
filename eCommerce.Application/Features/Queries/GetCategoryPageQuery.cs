using eCommerce.Application.DTOs.Common;
using eCommerce.Domain.Entities;
using MediatR;
using System.ComponentModel;

namespace eCommerce.Application.Features.Queries
{
    public class GetCategoryPageQuery : IRequest<PaginatedList<Category>>
    {
        public int Page { get; set; } = 1;

        public int Size { get; set; } = 20;
    }
}
using eCommerce.Application.DTOs.Common;
using eCommerce.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Application.Features.Queries
{
    public class GetCategoryPageQuery : IRequest<PaginatedList<Category>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
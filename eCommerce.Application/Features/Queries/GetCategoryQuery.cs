using eCommerce.Application.DTOs.CategoryDtos;
using eCommerce.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Application.Features.Queries
{
    public class GetCategoryQuery : IRequest<CategoryWithProductsDto?>
    {
        [Required]
        public int id { get; set; }
    }
}
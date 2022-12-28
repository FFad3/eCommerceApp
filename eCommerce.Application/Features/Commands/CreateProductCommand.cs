using eCommerce.Application.Common.Mappings;
using eCommerce.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Application.Features.Commands
{
    public class CreateProductCommand : IRequest<int>, IMapTo<Product>
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
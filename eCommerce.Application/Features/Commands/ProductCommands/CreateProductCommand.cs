using eCommerce.Application.Common.Mappings;
using eCommerce.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Application.Features.Commands.ProductCommands
{
    public class CreateProductCommand : IRequest<int>, IMapTo<Product>
    {
        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public int CategoryId { get; set; }

        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? ImgUrl { get; set; }
    }
}
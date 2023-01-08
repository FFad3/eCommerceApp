using eCommerce.Application.Common.Mappings;
using eCommerce.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Application.Features.Commands
{
    public class UpdateCategoryCommand : IRequest<int?>, IMapTo<Category>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = default!;
    }
}
using eCommerce.Application.Common.Mappings;
using eCommerce.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Application.Features.Commands
{
    public class CreateCategoryCommand : IRequest<int>, IMapTo<Category>
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Application.Features.Commands
{
    public class UpdateCategoryCommand : IRequest<int?>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
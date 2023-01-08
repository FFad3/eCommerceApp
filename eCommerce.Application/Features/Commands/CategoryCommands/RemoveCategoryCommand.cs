using MediatR;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Application.Features.Commands
{
    public class RemoveCategoryCommand : IRequest<bool>
    {
        [Required]
        public int Id { get; set; }
    }
}
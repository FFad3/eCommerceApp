using eCommerce.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Application.Features.Queries
{
    public class GetCategoryQuery : IRequest<Category?>
    {
        [Required]
        public int id { get; set; }
    }
}
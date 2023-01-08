using MediatR;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Application.Features.Queries.Common

{
    public class GetSingleItemQuery<T> : IRequest<T?> where T : class
    {
        [Required]
        public int Id { get; set; }
    }
}
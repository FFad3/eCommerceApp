using eCommerce.Application.DTOs.CategoryDtos;
using MediatR;

namespace eCommerce.Application.Features.Queries
{
    public class GetCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}
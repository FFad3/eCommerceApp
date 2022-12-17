using eCommerce.Application.Common.Mappings;
using eCommerce.Domain.Entities;
using MediatR;

namespace eCommerce.Application.Features.Commands
{
    public class CreateCategoryCommand : IRequest<int>, IMapTo<Category>
    {
        public string Name { get; set; } = String.Empty;
    }
}
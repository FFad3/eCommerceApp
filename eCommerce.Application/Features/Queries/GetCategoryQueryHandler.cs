using eCommerce.Application.Contracts.Persistence.Repositories;
using eCommerce.Domain.Entities;
using MediatR;

namespace eCommerce.Application.Features.Queries
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Category?>
    {
        private readonly ICategoryRepository _repo;

        public GetCategoryQueryHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<Category?> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _repo.FindAsync(x => x.Id == request.id, cancellationToken);
            return result;
        }
    }
}
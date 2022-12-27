using eCommerce.Application.Contracts.Persistence.Repositories;
using eCommerce.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerce.Application.Features.Queries
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Category?>
    {
        private readonly ICategoryRepository _repo;
        private readonly ILogger<GetCategoryQueryHandler> _logger;

        public GetCategoryQueryHandler(ICategoryRepository repo, ILogger<GetCategoryQueryHandler> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<Category?> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _repo.FindAsync(x => x.Id == request.id, cancellationToken);
            _logger.LogInformation("Get Category {@payload}", result);
            return result;
        }
    }
}
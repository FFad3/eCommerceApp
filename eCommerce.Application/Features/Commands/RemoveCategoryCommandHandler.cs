using eCommerce.Application.Contracts.Persistence.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerce.Application.Features.Commands
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, bool>
    {
        private readonly ICategoryRepository _repo;
        private readonly ILogger<RemoveCategoryCommandHandler> _logger;

        public RemoveCategoryCommandHandler(ICategoryRepository repo, ILogger<RemoveCategoryCommandHandler> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<bool> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.FindAsync(x => x.Id == request.Id, cancellationToken);
            if (obj is null)
            {
                _logger.LogInformation("Failed to remove cateogory Id:{@id}", request.Id);
                return false;
            }
            await _repo.Remove(obj);
            return await _repo.SaveChangesAsync(cancellationToken);
        }
    }
}
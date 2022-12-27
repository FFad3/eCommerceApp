using eCommerce.Application.Contracts.Persistence.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerce.Application.Features.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, int?>
    {
        private readonly ILogger<UpdateCategoryCommandHandler> _logger;
        private readonly ICategoryRepository _repo;

        public UpdateCategoryCommandHandler(ILogger<UpdateCategoryCommandHandler> logger, ICategoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<int?> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.FindAsync(x => x.Id == request.Id, cancellationToken);
            if (obj is null)
            {
                _logger.LogInformation("Category with Id:{id} not found", request.Id);
                return null;
            }
            obj.Name = request.Name;
            await _repo.Update(obj);
            await _repo.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Category with Id:{id} was updated", request.Id);
            return obj.Id;
        }
    }
}
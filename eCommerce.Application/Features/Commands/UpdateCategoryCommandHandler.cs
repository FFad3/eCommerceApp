using AutoMapper;
using eCommerce.Application.Contracts.Persistence.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerce.Application.Features.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, int?>
    {
        private readonly ILogger<UpdateCategoryCommandHandler> _logger;
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ILogger<UpdateCategoryCommandHandler> logger, ICategoryRepository repo, IMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<int?> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.FindAsync(x => x.Id == request.Id, cancellationToken);
            if (obj is null)
            {
                _logger.LogInformation("Category with Id:{id} not found", request.Id);
                return null;
            }

            var result = _mapper.Map(request, obj);

            await _repo.Update(result);
            await _repo.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Category with Id:{id} was updated", result.Id);
            return obj.Id;
        }
    }
}
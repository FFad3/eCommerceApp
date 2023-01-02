using AutoMapper;
using eCommerce.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerce.Application.Features.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, int?>
    {
        private readonly ILogger<UpdateCategoryCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ILogger<UpdateCategoryCommandHandler> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int?> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Category;
            var obj = await repo.FindAsync(x => x.Id == request.Id, cancellationToken);
            if (obj is null)
            {
                _logger.LogInformation("Category with Id:{id} not found", request.Id);
                return null;
            }

            var result = _mapper.Map(request, obj);

            await repo.Update(result);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Category with Id:{id} was updated", result.Id);
            return obj.Id;
        }
    }
}
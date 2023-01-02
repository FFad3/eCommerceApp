using eCommerce.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerce.Application.Features.Commands
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RemoveCategoryCommandHandler> _logger;

        public RemoveCategoryCommandHandler(IUnitOfWork unitOfWork, ILogger<RemoveCategoryCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var obj = await _unitOfWork.Category.FindAsync(x => x.Id == request.Id, cancellationToken);
            if (obj is null)
            {
                _logger.LogInformation("Failed to remove cateogory Id:{@id}", request.Id);
                return false;
            }
            await _unitOfWork.Category.Remove(obj);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
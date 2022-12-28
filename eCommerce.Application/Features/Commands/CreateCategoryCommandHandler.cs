using AutoMapper;
using eCommerce.Application.Contracts.Persistence.Repositories;
using eCommerce.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerce.Application.Features.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCategoryCommandHandler> _logger;

        public CreateCategoryCommandHandler(ICategoryRepository repo, IMapper mapper, ILogger<CreateCategoryCommandHandler> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var newCategory = _mapper.Map<Category>(request);
            newCategory = await _repo.AddAsync(newCategory, cancellationToken);
            await _repo.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Category {@newItem} saved in DB", newCategory);
            return newCategory.Id;
        }
    }
}
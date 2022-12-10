using AutoMapper;
using eCommerce.Application.Contracts.Persistence.Repositories;
using eCommerce.Domain.Entities;
using MediatR;

namespace eCommerce.Application.Features.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var newCategory = _mapper.Map<Category>(request);
            newCategory = await _repo.AddAsync(newCategory, cancellationToken);
            await _repo.SaveChangesAsync(cancellationToken);
            return newCategory.Id;
        }
    }
}
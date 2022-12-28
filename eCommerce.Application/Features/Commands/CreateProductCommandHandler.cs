using AutoMapper;
using eCommerce.Application.Contracts.Persistence.Repositories;
using eCommerce.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerce.Application.Features.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductCommandHandler> _logger;

        public CreateProductCommandHandler(IProductRepository repo, IMapper mapper, ILogger<CreateProductCommandHandler> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = _mapper.Map<Product>(request);
            newProduct = await _repo.AddAsync(newProduct, cancellationToken);
            await _repo.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Product {@newItem} saved in DB", newProduct);
            return newProduct.Id;
        }
    }
}
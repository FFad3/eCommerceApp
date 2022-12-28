using eCommerce.Application.Contracts.Persistence.Repositories;
using FluentValidation;

namespace eCommerce.Application.Features.Commands
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateProductCommandValidator(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("is null or empty string")
                .MaximumLength(100).WithMessage("must not exceed 100 characters")
                .MustAsync(IsNameUnique).WithMessage("must be unique");

            RuleFor(x => x.CategoryId)
                .NotNull().WithMessage("is null")
                .MustAsync(IsCategoryExist).WithMessage("does not exist");

            RuleFor(x => x.Price)
                .NotNull().WithMessage("is null")
                .GreaterThan(0).WithMessage("must be a positive number");

            RuleFor(x => x.Description)
                .MaximumLength(600).WithMessage("is to long");
        }

        private async Task<bool> IsNameUnique(string name, CancellationToken cancellationToken) =>
           await _productRepository.IsUnique(x => x.Name == name, cancellationToken);

        private async Task<bool> IsCategoryExist(int categoryId, CancellationToken cancellationToken) =>
             !await _categoryRepository.IsUnique(x => x.Id == categoryId, cancellationToken);
    }
}
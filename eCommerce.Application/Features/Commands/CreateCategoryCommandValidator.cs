using eCommerce.Application.Contracts.Persistence.Repositories;
using FluentValidation;

namespace eCommerce.Application.Features.Commands
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _repo;

        public CreateCategoryCommandValidator(ICategoryRepository repo)
        {
            _repo = repo;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters")
                .MustAsync(IsNameUnique);
        }

        private async Task<bool> IsNameUnique(string name, CancellationToken cancellationToken) =>
            await _repo.IsUnique(x => x.Name == name, cancellationToken);
    }
}
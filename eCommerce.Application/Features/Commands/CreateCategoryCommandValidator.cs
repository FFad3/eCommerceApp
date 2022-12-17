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
                .NotEmpty().WithMessage("is null or empty string")
                .MaximumLength(100).WithMessage("must not exceed 100 characters")
                .MustAsync(IsNameUnique).WithMessage("must be unique");
        }

        private async Task<bool> IsNameUnique(string name, CancellationToken cancellationToken) =>
            await _repo.IsUnique(x => x.Name == name, cancellationToken);
    }
}
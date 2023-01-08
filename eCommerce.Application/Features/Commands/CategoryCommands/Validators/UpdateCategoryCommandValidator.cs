using eCommerce.Application.Contracts.Persistence;
using FluentValidation;

namespace eCommerce.Application.Features.Commands
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("is null or empty string")
                .MaximumLength(100).WithMessage("must not exceed 100 characters")
                .MustAsync(IsNameUnique).WithMessage("must be unique");
        }

        private async Task<bool> IsNameUnique(string name, CancellationToken cancellationToken) =>
            await _unitOfWork.Category.IsUnique(x => x.Name == name && !x.IsRemoved, cancellationToken);
    }
}
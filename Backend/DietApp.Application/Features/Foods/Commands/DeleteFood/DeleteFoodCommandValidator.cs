using FluentValidation;
using DietApp.Application.Features.Foods.Commands.DeleteFood;

namespace DietApp.Application.Features.Foods.Commands.DeleteFood
{
    public class DeleteFoodCommandValidator : AbstractValidator<DeleteFoodCommand>
    {
        public DeleteFoodCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Yiyecek ID'si boş olamaz.");
        }
    }
} 
using FluentValidation;

namespace DietApp.Application.Features.DailyNutritions.Commands.DeleteDailyNutrition
{
    public class DeleteDailyNutritionCommandValidator : AbstractValidator<DeleteDailyNutritionCommand>
    {
        public DeleteDailyNutritionCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Günlük besin kaydı ID'si boş olamaz.");
        }
    }
} 
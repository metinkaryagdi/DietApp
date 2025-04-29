using FluentValidation;

namespace DietApp.Application.Features.Meals.Commands.RemoveFoodFromMeal
{
    public class RemoveFoodFromMealCommandValidator : AbstractValidator<RemoveFoodFromMealCommand>
    {
        public RemoveFoodFromMealCommandValidator()
        {
            RuleFor(x => x.MealId)
                .NotEmpty().WithMessage("Öğün ID'si boş olamaz.");

            RuleFor(x => x.FoodId)
                .NotEmpty().WithMessage("Yiyecek ID'si boş olamaz.");
        }
    }
} 
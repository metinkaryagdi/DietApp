using FluentValidation;

namespace DietApp.Application.Features.Meals.Commands.AddFoodToMeal
{
    public class AddFoodToMealCommandValidator : AbstractValidator<AddFoodToMealCommand>
    {
        public AddFoodToMealCommandValidator()
        {
            RuleFor(x => x.MealId)
                .NotEmpty().WithMessage("Öğün ID'si boş olamaz.");

            RuleFor(x => x.FoodId)
                .NotEmpty().WithMessage("Yiyecek ID'si boş olamaz.");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Miktar boş olamaz.")
                .GreaterThan(0).WithMessage("Miktar 0'dan büyük olmalıdır.");
        }
    }
} 
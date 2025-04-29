using DietApp.Application.Features.DietPlans.Commands.CreateDietPlan;
using FluentValidation;

public class CreateMealDtoValidator : AbstractValidator<CreateMealDto>
{
    public CreateMealDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Meal name is required.");

        RuleFor(x => x.MealTime)
            .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Meal time cannot be in the past.");

        RuleForEach(x => x.MealFoods).SetValidator(new CreateMealFoodDtoValidator());
    }
}

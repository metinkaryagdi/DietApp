using DietApp.Application.Features.DietPlans.Commands.CreateDietPlan;
using FluentValidation;

public class CreateMealFoodDtoValidator : AbstractValidator<CreateMealFoodDto>
{
    public CreateMealFoodDtoValidator()
    {
      RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.")
            .LessThanOrEqualTo(1000).WithMessage("Quantity must not exceed 1000.");
        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

        RuleFor(x => x.Food).NotNull().WithMessage("Food information is required.");
    }
}

using FluentValidation;

namespace DietApp.Application.Features.DietPlans.Commands.CreateDietPlan
{
    public class CreateDietPlanValidator : AbstractValidator<CreateDietPlanCommand>
    {
        public CreateDietPlanValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Plan name is required.");
            RuleFor(x => x.Meals).NotEmpty().WithMessage("Meals should not be empty.");
        }
    }
}

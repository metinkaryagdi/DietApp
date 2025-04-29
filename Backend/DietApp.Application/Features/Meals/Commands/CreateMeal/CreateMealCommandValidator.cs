using FluentValidation;

namespace DietApp.Application.Features.Meals.Commands.CreateMeal
{
    public class CreateMealCommandValidator : AbstractValidator<CreateMealCommand>
    {
        public CreateMealCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Öğün adı boş olamaz.")
                .MaximumLength(100).WithMessage("Öğün adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Tarih boş olamaz.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı ID'si boş olamaz.");
        }
    }
} 
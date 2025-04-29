using FluentValidation;

namespace DietApp.Application.Features.DailyNutritions.Commands.UpdateDailyNutrition
{
    public class UpdateDailyNutritionCommandValidator : AbstractValidator<UpdateDailyNutritionCommand>
    {
        public UpdateDailyNutritionCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Günlük besin kaydı ID'si boş olamaz.");

            RuleFor(x => x.TotalCalories)
                .NotEmpty().WithMessage("Toplam kalori alanı boş olamaz.")
                .GreaterThan(0).WithMessage("Toplam kalori 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(10000).WithMessage("Toplam kalori 10000'den büyük olamaz.");

            RuleFor(x => x.TotalProtein)
                .NotEmpty().WithMessage("Toplam protein alanı boş olamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Toplam protein 0'dan küçük olamaz.")
                .LessThanOrEqualTo(500).WithMessage("Toplam protein 500'den büyük olamaz.");

            RuleFor(x => x.TotalCarbohydrate)
                .NotEmpty().WithMessage("Toplam karbonhidrat alanı boş olamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Toplam karbonhidrat 0'dan küçük olamaz.")
                .LessThanOrEqualTo(1000).WithMessage("Toplam karbonhidrat 1000'den büyük olamaz.");

            RuleFor(x => x.TotalFat)
                .NotEmpty().WithMessage("Toplam yağ alanı boş olamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Toplam yağ 0'dan küçük olamaz.")
                .LessThanOrEqualTo(500).WithMessage("Toplam yağ 500'den büyük olamaz.");

            RuleFor(x => x.Notes)
                .MaximumLength(500).WithMessage("Notlar en fazla 500 karakter olabilir.");
        }
    }
} 
using FluentValidation;
using DietApp.Application.Features.Foods.Commands.UpdateFood;

namespace DietApp.Application.Features.Foods.Commands.UpdateFood
{
    public class UpdateFoodCommandValidator : AbstractValidator<UpdateFoodCommand>
    {
        public UpdateFoodCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Yiyecek ID'si boş olamaz.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Yiyecek adı boş olamaz.")
                .MaximumLength(100).WithMessage("Yiyecek adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.Calories)
                .NotEmpty().WithMessage("Kalori değeri boş olamaz.")
                .GreaterThan(0).WithMessage("Kalori değeri 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(1000).WithMessage("Kalori değeri 1000'den büyük olamaz.");

            RuleFor(x => x.Protein)
                .NotEmpty().WithMessage("Protein değeri boş olamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Protein değeri negatif olamaz.")
                .LessThanOrEqualTo(100).WithMessage("Protein değeri 100'den büyük olamaz.");

            RuleFor(x => x.Carbohydrate)
                .NotEmpty().WithMessage("Karbonhidrat değeri boş olamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Karbonhidrat değeri negatif olamaz.")
                .LessThanOrEqualTo(100).WithMessage("Karbonhidrat değeri 100'den büyük olamaz.");

            RuleFor(x => x.Fat)
                .NotEmpty().WithMessage("Yağ değeri boş olamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Yağ değeri negatif olamaz.")
                .LessThanOrEqualTo(100).WithMessage("Yağ değeri 100'den büyük olamaz.");

            RuleFor(x => x.Unit)
                .NotEmpty().WithMessage("Birim alanı boş olamaz.")
                .MaximumLength(20).WithMessage("Birim en fazla 20 karakter olabilir.");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Miktar değeri boş olamaz.")
                .GreaterThan(0).WithMessage("Miktar değeri 0'dan büyük olmalıdır.")
 
using FluentValidation;

namespace DietApp.Application.Features.Foods.Commands.CreateFood
{
    public class CreateFoodCommandValidator : AbstractValidator<CreateFoodCommand>
    {
        public CreateFoodCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Besin adı boş olamaz.")
                .MaximumLength(100).WithMessage("Besin adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.Calories)
                .NotEmpty().WithMessage("Kalori alanı boş olamaz.")
                .GreaterThan(0).WithMessage("Kalori 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(1000).WithMessage("Kalori 1000'den büyük olamaz.");

            RuleFor(x => x.Protein)
                .NotEmpty().WithMessage("Protein alanı boş olamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Protein 0'dan küçük olamaz.")
                .LessThanOrEqualTo(100).WithMessage("Protein 100'den büyük olamaz.");

            RuleFor(x => x.Carbohydrate)
                .NotEmpty().WithMessage("Karbonhidrat alanı boş olamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Karbonhidrat 0'dan küçük olamaz.")
                .LessThanOrEqualTo(100).WithMessage("Karbonhidrat 100'den büyük olamaz.");

            RuleFor(x => x.Fat)
                .NotEmpty().WithMessage("Yağ alanı boş olamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Yağ 0'dan küçük olamaz.")
                .LessThanOrEqualTo(100).WithMessage("Yağ 100'den büyük olamaz.");

            RuleFor(x => x.Unit)
                .NotEmpty().WithMessage("Birim alanı boş olamaz.")
                .MaximumLength(20).WithMessage("Birim en fazla 20 karakter olabilir.");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Miktar alanı boş olamaz.")
                .GreaterThan(0).WithMessage("Miktar 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(1000).WithMessage("Miktar 1000'den büyük olamaz.");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Kategori alanı boş olamaz.")
                .MaximumLength(50).WithMessage("Kategori en fazla 50 karakter olabilir.");
        }
    }
} 
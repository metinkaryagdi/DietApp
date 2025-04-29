using FluentValidation;

namespace DietApp.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Kullanıcı ID'si boş olamaz.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad alanı boş olamaz.")
                .MaximumLength(100).WithMessage("Ad en fazla 100 karakter olabilir.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad alanı boş olamaz.")
                .MaximumLength(100).WithMessage("Soyad en fazla 100 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email alanı boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.")
                .MaximumLength(256).WithMessage("Email en fazla 256 karakter olabilir.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Doğum tarihi alanı boş olamaz.")
                .LessThan(DateTime.Now.AddYears(-13)).WithMessage("Kullanıcı en az 13 yaşında olmalıdır.");

            RuleFor(x => x.Height)
                .NotEmpty().WithMessage("Boy alanı boş olamaz.")
                .GreaterThan(0).WithMessage("Boy 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(300).WithMessage("Boy 300 cm'den küçük olmalıdır.");

            RuleFor(x => x.Weight)
                .NotEmpty().WithMessage("Kilo alanı boş olamaz.")
                .GreaterThan(0).WithMessage("Kilo 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(500).WithMessage("Kilo 500 kg'dan küçük olmalıdır.");

            RuleFor(x => x.TargetWeight)
                .NotEmpty().WithMessage("Hedef kilo alanı boş olamaz.")
                .GreaterThan(0).WithMessage("Hedef kilo 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(500).WithMessage("Hedef kilo 500 kg'dan küçük olmalıdır.");
        }
    }
} 
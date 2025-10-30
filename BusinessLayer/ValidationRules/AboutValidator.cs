using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class AboutValidator : AbstractValidator<About>
{
    public AboutValidator()
    {
        RuleFor(a => a.Description).NotEmpty().WithMessage("Açıklamayı boş geçemezsiniz");
        RuleFor(x => x.Image1).NotEmpty().WithMessage("Görsel Seçiniz");
        RuleFor(x => x.Description).MinimumLength(50).WithMessage("Lütfen en az 50 Karakter giriniz");
    }
}
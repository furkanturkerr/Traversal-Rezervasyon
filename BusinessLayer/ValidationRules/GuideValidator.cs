using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class GuideValidator : AbstractValidator<Guide>
{
      public GuideValidator()
      {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Rehber Adını Giriniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen Rehber Açıklamasını Giriniz");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen Rehber Görselini Giriniz");
      }   
}
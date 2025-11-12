using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTOs>
{
    public AppUserRegisterValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Boş geçilemez");
        RuleFor(x => x.SurName).NotEmpty().WithMessage("Boş geçilemez");
        RuleFor(x => x.Mail).NotEmpty().WithMessage("Boş geçilemez");
        RuleFor(x => x.UserName).NotEmpty().WithMessage("Boş geçilemez");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Boş geçilemez");
        RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Boş geçilemez");
        RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Şifreler uyuşmuyor");
    }
}
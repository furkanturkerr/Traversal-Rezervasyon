using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class AnnouncmentUpdateValidation : AbstractValidator<Announcement>
{
    public AnnouncmentUpdateValidation ()
    {
        RuleFor(x => x.Content).NotEmpty().WithMessage("Boş geçilemez.");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Boş geçilemez.");
        RuleFor(x => x.Date).NotEmpty().WithMessage("Boş geçilemez.");
    }
}
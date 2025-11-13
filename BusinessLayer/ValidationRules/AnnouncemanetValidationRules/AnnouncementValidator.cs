using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class AnnouncementValidator : AbstractValidator<AnnouncementAddDto>
{
    public AnnouncementValidator()
    {
        RuleFor(x => x.Content).NotEmpty().WithMessage("Boş geçilemez.");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Boş geçilemez.");
    }
}
using System.Data;
using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.ContactUs;

public class SenContactUsValidator: AbstractValidator<SendMessageDTO>
{
    public SenContactUsValidator()
    {
        RuleFor(x=> x.Name).NotEmpty().WithMessage("Zorunlu");
        RuleFor(x=> x.Mail).NotEmpty().WithMessage("Zorunlu");
        RuleFor(x=> x.MessageBody).NotEmpty().WithMessage("Zorunlu");
        RuleFor(x=> x.Subject).NotEmpty().WithMessage("Zorunlu");
    }
}
using MediatR;

namespace Traversal_Rezervasyon.CQRS.Commands.GuideCommants;

public class CreateGuideCommants : IRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public bool Status { get; set; }
}
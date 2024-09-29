using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Section.Commands.DeleteSection;

public class DeleteSectionCommandValidator : AbstractValidator<DeleteSectionCommand>
{
    public DeleteSectionCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Section ID is required.");
    }
}

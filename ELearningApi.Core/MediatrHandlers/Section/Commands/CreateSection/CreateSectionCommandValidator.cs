using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Section.Commands.CreateSection;

public class CreateSectionCommandValidator : AbstractValidator<CreateSectionCommand>
{
    public CreateSectionCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Section title is required.")
            .MaximumLength(100).WithMessage("Section title must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Section description must not exceed 500 characters.");

        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("Course ID is required.");
    }
}

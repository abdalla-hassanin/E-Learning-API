using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Lecture.Command.AddResourceToLecture;

public class AddResourceToLectureCommandValidator : AbstractValidator<AddResourceToLectureCommand>
{
    public AddResourceToLectureCommandValidator()
    {
        RuleFor(x => x.LectureId)
            .NotEmpty().WithMessage("Lecture ID is required.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Resource title is required.")
            .MaximumLength(200).WithMessage("Resource title must not exceed 200 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Resource description must not exceed 1000 characters.");

        RuleFor(x => x.Url)
            .NotEmpty().WithMessage("Resource URL is required.")
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
            .WithMessage("Resource URL must be a valid URL.");

        RuleFor(x => x.Type)
            .IsInEnum().WithMessage("Invalid resource type.");
    }
}


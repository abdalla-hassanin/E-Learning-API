using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Progress.Commands.MarkLectureComplete;

public class MarkLectureCompleteCommandValidator : AbstractValidator<MarkLectureCompleteCommand>
{
    public MarkLectureCompleteCommandValidator()
    {
        RuleFor(x => x.EnrollmentId)
            .NotEmpty().WithMessage("Enrollment ID is required.");

        RuleFor(x => x.LectureId)
            .NotEmpty().WithMessage("Lecture ID is required.");
    }
}

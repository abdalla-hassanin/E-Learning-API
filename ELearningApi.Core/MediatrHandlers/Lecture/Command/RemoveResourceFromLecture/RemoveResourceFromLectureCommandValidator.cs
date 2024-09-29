using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Lecture.Command.RemoveResourceFromLecture;

public class RemoveResourceFromLectureCommandValidator : AbstractValidator<RemoveResourceFromLectureCommand>
{
    public RemoveResourceFromLectureCommandValidator()
    {
        RuleFor(x => x.LectureId)
            .NotEmpty().WithMessage("Lecture ID is required.");

        RuleFor(x => x.ResourceId)
            .NotEmpty().WithMessage("Resource ID is required.");
    }
}

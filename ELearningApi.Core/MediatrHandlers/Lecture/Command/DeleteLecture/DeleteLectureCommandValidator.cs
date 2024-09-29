using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Lecture.Command.DeleteLecture;
public class DeleteLectureCommandValidator : AbstractValidator<DeleteLectureCommand>
{
    public DeleteLectureCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Lecture ID is required.");
    }
}

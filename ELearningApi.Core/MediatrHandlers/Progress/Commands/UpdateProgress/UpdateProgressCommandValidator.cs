using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Progress.Commands.UpdateProgress;

public class UpdateProgressCommandValidator : AbstractValidator<UpdateProgressCommand>
{
    public UpdateProgressCommandValidator()
    {
        RuleFor(x => x.EnrollmentId)
            .NotEmpty().WithMessage("Enrollment ID is required.");

        RuleFor(x => x.LectureId)
            .NotEmpty().WithMessage("Lecture ID is required.");

        RuleFor(x => x.ProgressPercentage)
            .InclusiveBetween(0, 100).WithMessage("Progress percentage must be between 0 and 100.");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid progress status.");
    }
}


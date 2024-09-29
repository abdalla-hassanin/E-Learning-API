using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Progress.Commands.ResetProgress;

public class ResetProgressCommandValidator : AbstractValidator<ResetProgressCommand>
{
    public ResetProgressCommandValidator()
    {
        RuleFor(x => x.EnrollmentId)
            .NotEmpty().WithMessage("Enrollment ID is required.");
    }
}

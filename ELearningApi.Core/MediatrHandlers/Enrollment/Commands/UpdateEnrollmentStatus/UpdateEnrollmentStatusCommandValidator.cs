using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Enrollment.Commands.UpdateEnrollmentStatus;

public class UpdateEnrollmentStatusCommandValidator : AbstractValidator<UpdateEnrollmentStatusCommand>
{
    public UpdateEnrollmentStatusCommandValidator()
    {
        RuleFor(x => x.EnrollmentId)
            .NotEmpty().WithMessage("Enrollment ID is required.");

        RuleFor(x => x.NewStatus)
            .IsInEnum().WithMessage("Invalid enrollment status.");
    }
}

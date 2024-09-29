using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Progress.Queries.GetProgressForEnrollment;

public class GetProgressForEnrollmentQueryValidator : AbstractValidator<GetProgressForEnrollmentQuery>
{
    public GetProgressForEnrollmentQueryValidator()
    {
        RuleFor(x => x.EnrollmentId)
            .NotEmpty().WithMessage("Enrollment ID is required.")
            .Must(id => id != Guid.Empty).WithMessage("Invalid Enrollment ID.");
    }
}
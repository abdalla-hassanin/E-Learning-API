using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Enrollment.Queries.CheckEnrollmentStatus;

public class CheckEnrollmentStatusQueryValidator : AbstractValidator<CheckEnrollmentStatusQuery>
{
    public CheckEnrollmentStatusQueryValidator()
    {
        RuleFor(x => x.StudentId)
            .NotEmpty().WithMessage("Student ID is required.");

        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("Course ID is required.");
    }
}

using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Enrollment.Queries.GetEnrollmentById;

public class GetEnrollmentByIdQueryValidator : AbstractValidator<GetEnrollmentByIdQuery>
{
    public GetEnrollmentByIdQueryValidator()
    {
        RuleFor(x => x.EnrollmentId)
            .NotEmpty().WithMessage("Enrollment ID is required.");
    }
}

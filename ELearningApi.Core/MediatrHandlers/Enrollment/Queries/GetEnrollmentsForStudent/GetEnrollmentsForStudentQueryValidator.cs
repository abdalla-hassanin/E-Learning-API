using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Enrollment.Queries.GetEnrollmentsForStudent;

public class GetEnrollmentsForStudentQueryValidator : AbstractValidator<GetEnrollmentsForStudentQuery>
{
    public GetEnrollmentsForStudentQueryValidator()
    {
        RuleFor(x => x.StudentId)
            .NotEmpty().WithMessage("Student ID is required.");
    }
}


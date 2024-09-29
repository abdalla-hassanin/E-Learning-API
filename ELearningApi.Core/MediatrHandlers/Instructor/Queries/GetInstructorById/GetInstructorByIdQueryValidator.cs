using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Instructor.Queries.GetInstructorById;

public class GetInstructorByIdQueryValidator : AbstractValidator<GetInstructorByIdQuery>
{
    public GetInstructorByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Instructor ID is required.");
    }
}

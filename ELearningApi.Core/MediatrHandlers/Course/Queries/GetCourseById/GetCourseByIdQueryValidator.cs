using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Course.Queries.GetCourseById;

public class GetCourseByIdQueryValidator : AbstractValidator<GetCourseByIdQuery>
{
    public GetCourseByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Course ID is required");
    }
}

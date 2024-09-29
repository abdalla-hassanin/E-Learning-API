using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Course.Queries.GetCoursesByInstructor;

public class GetCoursesByInstructorQueryValidator : AbstractValidator<GetCoursesByInstructorQuery>
{
    public GetCoursesByInstructorQueryValidator()
    {
        RuleFor(x => x.InstructorId).NotEmpty().WithMessage("Instructor ID is required");
    }
}

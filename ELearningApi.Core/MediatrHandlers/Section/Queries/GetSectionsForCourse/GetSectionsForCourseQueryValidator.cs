using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Section.Queries.GetSectionsForCourse;

public class GetSectionsForCourseQueryValidator : AbstractValidator<GetSectionsForCourseQuery>
{
    public GetSectionsForCourseQueryValidator()
    {
        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("Course ID is required.");
    }
}

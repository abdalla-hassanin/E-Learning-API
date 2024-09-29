using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizzesByCourse;

public class GetQuizzesByCourseQueryValidator: AbstractValidator<GetQuizzesByCourseQuery>
{
    public GetQuizzesByCourseQueryValidator()
    {
        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("Course ID is required.");

    }

}
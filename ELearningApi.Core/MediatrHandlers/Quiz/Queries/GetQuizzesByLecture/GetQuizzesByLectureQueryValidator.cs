using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizzesByLecture;

public class GetQuizzesByLectureQueryValidator: AbstractValidator<GetQuizzesByLectureQuery>
{
    public GetQuizzesByLectureQueryValidator()
    {
        RuleFor(x => x.LectureId)
            .NotEmpty().WithMessage("Lecture ID is required.");

    }

}
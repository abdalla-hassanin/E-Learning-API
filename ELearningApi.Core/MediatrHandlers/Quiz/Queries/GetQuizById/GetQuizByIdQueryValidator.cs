using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizById;

public class GetQuizByIdQueryValidator: AbstractValidator<GetQuizByIdQuery>
{
    public GetQuizByIdQueryValidator()
    {
        RuleFor(x => x.QuizId)
            .NotEmpty().WithMessage("Quiz ID is required.");
    }
    
}
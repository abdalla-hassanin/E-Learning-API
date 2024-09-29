using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt.Queries.GetQuizAttemptsForQuiz;

public class GetQuizAttemptsForQuizQueryValidator : AbstractValidator<GetQuizAttemptsForQuizQuery>
{
    public GetQuizAttemptsForQuizQueryValidator()
    {
        RuleFor(x => x.QuizId)
            .NotEmpty().WithMessage("Quiz ID is required.");
    }
}

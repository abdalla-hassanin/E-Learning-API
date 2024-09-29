using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt.Queries.GetQuizAttemptResult;

public class GetQuizAttemptResultQueryValidator : AbstractValidator<GetQuizAttemptResultQuery>
{
    public GetQuizAttemptResultQueryValidator()
    {
        RuleFor(x => x.AttemptId)
            .NotEmpty().WithMessage("Quiz attempt ID is required.");
    }
}

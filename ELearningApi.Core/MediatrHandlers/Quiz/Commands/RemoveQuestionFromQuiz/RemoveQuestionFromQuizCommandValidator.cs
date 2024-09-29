using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Commands.RemoveQuestionFromQuiz;

public class RemoveQuestionFromQuizCommandValidator : AbstractValidator<RemoveQuestionFromQuizCommand>
{
    public RemoveQuestionFromQuizCommandValidator()
    {
        RuleFor(x => x.QuizId).NotEmpty();
        RuleFor(x => x.QuestionId).NotEmpty();
    }
}


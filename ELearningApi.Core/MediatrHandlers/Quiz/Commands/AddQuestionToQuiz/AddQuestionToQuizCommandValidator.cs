using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Commands.AddQuestionToQuiz;

public class AddQuestionToQuizCommandValidator : AbstractValidator<AddQuestionToQuizCommand>
{
    public AddQuestionToQuizCommandValidator()
    {
        RuleFor(x => x.QuizId).NotEmpty();
        RuleFor(x => x.Question).NotNull();
        RuleFor(x => x.Question.QuestionText).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Question.Type).IsInEnum();
        RuleFor(x => x.Question.Points).GreaterThan(0);
        RuleFor(x => x.Question.DifficultyLevel).InclusiveBetween(1, 5);
    }
}

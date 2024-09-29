using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Commands.UpdateQuestion;

public class UpdateQuestionCommandValidator : AbstractValidator<UpdateQuestionCommand>
{
    public UpdateQuestionCommandValidator()
    {
        RuleFor(x => x.QuizId).NotEmpty();
        RuleFor(x => x.Question).NotNull();
        RuleFor(x => x.Question.Id).NotEmpty();
        RuleFor(x => x.Question.QuestionText).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Question.Type).IsInEnum();
        RuleFor(x => x.Question.Points).GreaterThan(0);
        RuleFor(x => x.Question.DifficultyLevel).InclusiveBetween(1, 5);
    }
}


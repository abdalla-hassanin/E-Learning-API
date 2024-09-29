using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Commands.DeleteQuiz;

public class DeleteQuizCommandValidator : AbstractValidator<DeleteQuizCommand>
{
    public DeleteQuizCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}


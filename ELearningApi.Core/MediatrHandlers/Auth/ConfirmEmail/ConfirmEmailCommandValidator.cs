using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Auth.ConfirmEmail;

public class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommand>
{
    public ConfirmEmailCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID is required.");
        RuleFor(x => x.Token).NotEmpty().WithMessage("Token is required.");
    }
}

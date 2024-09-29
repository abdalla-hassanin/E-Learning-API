using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Auth.ResetPassword;

public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("A valid email is required.");
        RuleFor(x => x.Token).NotEmpty().WithMessage("Token is required.");
        RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(8).WithMessage("New password must be at least 8 characters long.");
    }
}


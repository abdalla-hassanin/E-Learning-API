using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Auth.RegisterInstructor;

public class RegisterInstructorCommandValidator : AbstractValidator<RegisterInstructorCommand>
{
    public RegisterInstructorCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("A valid email is required.");
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8).WithMessage("Password must be at least 8 characters long.");
        RuleFor(x => x.Expertise).NotEmpty().WithMessage("Expertise is required.");
        RuleFor(x => x.Biography).NotEmpty().WithMessage("Biography is required.");
    }
}

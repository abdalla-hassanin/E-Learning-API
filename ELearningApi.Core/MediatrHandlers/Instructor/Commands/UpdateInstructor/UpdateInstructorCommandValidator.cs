using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Instructor.Commands.UpdateInstructor;

public class UpdateInstructorCommandValidator : AbstractValidator<UpdateInstructorCommand>
{
    public UpdateInstructorCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Instructor ID is required.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email address is required.");

        RuleFor(x => x.Expertise)
            .NotEmpty().WithMessage("Expertise is required.")
            .MaximumLength(100).WithMessage("Expertise must not exceed 100 characters.");

        RuleFor(x => x.Biography)
            .NotEmpty().WithMessage("Biography is required.")
            .MaximumLength(500).WithMessage("Biography must not exceed 500 characters.");
    }
}


using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Student.Queries.GetStudentById;

public class GetStudentByIdQueryValidator : AbstractValidator<GetStudentByIdQuery>
{
    public GetStudentByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Student ID is required.");
    }
}

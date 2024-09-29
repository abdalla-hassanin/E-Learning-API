using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Lecture.Queries.GetLectureById;

public class GetLectureByIdQueryValidator : AbstractValidator<GetLectureByIdQuery>
{
    public GetLectureByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Lecture ID is required.")
            .Must(id => id != Guid.Empty).WithMessage("Invalid Lecture ID.");
    }
}

using FluentValidation;

namespace ELearningApi.Core.MediatrHandlers.Lecture.Queries.GetLecturesForSection;

public class GetLecturesForSectionQueryValidator : AbstractValidator<GetLecturesForSectionQuery>
{
    public GetLecturesForSectionQueryValidator()
    {
        RuleFor(x => x.SectionId)
            .NotEmpty().WithMessage("Section ID is required.")
            .Must(id => id != Guid.Empty).WithMessage("Invalid Section ID.");
    }
}


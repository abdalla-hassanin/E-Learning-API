using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Section.Commands.CreateSection;

public class CreateSectionCommand : IRequest<ApiResponse<SectionDto>>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CourseId { get; set; }
}

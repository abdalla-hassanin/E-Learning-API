using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Section.Commands.UpdateSection;

public class UpdateSectionCommand : IRequest<ApiResponse<SectionDto>>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int OrderIndex { get; set; }
}
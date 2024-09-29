using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Section.Queries.GetSectionById;

public class GetSectionByIdQuery : IRequest<ApiResponse<SectionDto>>
{
    public Guid Id { get; set; }
}

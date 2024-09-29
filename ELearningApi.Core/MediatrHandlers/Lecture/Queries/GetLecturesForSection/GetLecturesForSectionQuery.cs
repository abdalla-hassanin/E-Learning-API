using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Lecture.Queries.GetLecturesForSection;

public class GetLecturesForSectionQuery : IRequest<ApiResponse<IEnumerable<LectureDto>>>
{
    public Guid SectionId { get; set; }
}

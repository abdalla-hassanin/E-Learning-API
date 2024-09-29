using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Core.MediatrHandlers.Search.Dtos;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Search.SearchLectures;

public class SearchLecturesQuery : IRequest<ApiResponse<IEnumerable<LectureDto>>>
{
    public string SearchTerm { get; set; }
    public Guid? CourseId { get; set; }
}


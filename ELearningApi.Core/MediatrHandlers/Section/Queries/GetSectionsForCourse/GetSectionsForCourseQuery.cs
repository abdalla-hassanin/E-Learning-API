using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Section.Queries.GetSectionsForCourse;

public class GetSectionsForCourseQuery : IRequest<ApiResponse<IEnumerable<SectionDto>>>
{
    public Guid CourseId { get; set; }
    
}
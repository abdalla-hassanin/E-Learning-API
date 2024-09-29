using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Data.Enums;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Course.Queries.SearchCourses;

public class SearchCoursesQuery : IRequest<ApiResponse<SearchCoursesResult>>
{
    public string SearchTerm { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public CourseLevel? Level { get; set; }
    public Guid? CategoryId { get; set; }
}

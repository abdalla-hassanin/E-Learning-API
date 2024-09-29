using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Core.MediatrHandlers.Search.Dtos;
using ELearningApi.Data.Enums;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Search.SearchCourses;

public class SearchCoursesQuery : IRequest<ApiResponse<IEnumerable<CourseDto>>>
{
    public string SearchTerm { get; set; }
    public CourseLevel? Level { get; set; }
    public Guid? CategoryId { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
}

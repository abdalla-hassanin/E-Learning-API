namespace ELearningApi.Core.MediatrHandlers.Course.Queries.SearchCourses;

public class SearchCoursesResult
{
    public IEnumerable<CourseDto> Courses { get; set; }
    public int TotalCount { get; set; }
}

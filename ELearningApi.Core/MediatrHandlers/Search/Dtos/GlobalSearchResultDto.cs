namespace ELearningApi.Core.MediatrHandlers.Search.Dtos;

public class GlobalSearchResultDto
{
    public IEnumerable<CourseDto> Courses { get; set; }
    public IEnumerable<InstructorDto> Instructors { get; set; }
    public IEnumerable<LectureDto> Lectures { get; set; }
}

using ELearningApi.Data.Entities;
using ELearningApi.Data.Enums;

namespace ELearningApi.Service.IService;
public interface ISearchService
{
    Task<IEnumerable<Course>> SearchCoursesAsync(string searchTerm, CourseLevel? level = null, Guid? categoryId = null, decimal? minPrice = null, decimal? maxPrice = null, CancellationToken cancellationToken = default);
    Task<IEnumerable<Instructor>> SearchInstructorsAsync(string searchTerm, string? expertise = null, CancellationToken cancellationToken = default);
    Task<IEnumerable<Lecture>> SearchLecturesAsync(string searchTerm, Guid? courseId = null, CancellationToken cancellationToken = default);
    Task<(IEnumerable<Course> Courses, IEnumerable<Instructor> Instructors, IEnumerable<Lecture> Lectures)> PerformGlobalSearchAsync(string searchTerm, CancellationToken cancellationToken = default);

}

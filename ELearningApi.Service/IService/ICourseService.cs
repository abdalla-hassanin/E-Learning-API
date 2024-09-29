using ELearningApi.Data.Entities;
using ELearningApi.Data.Enums;

namespace ELearningApi.Service.IService;

public interface ICourseService
{
    Task<Course> CreateCourseAsync(Course course, CancellationToken cancellationToken = default);
    Task<Course> GetCourseByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Course> UpdateCourseAsync(Course course, CancellationToken cancellationToken = default);
    Task DeleteCourseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Course>> GetCoursesByCategoryAsync(Guid categoryId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Course>> GetCoursesByInstructorAsync(Guid instructorId, CancellationToken cancellationToken = default);
    Task<(IEnumerable<Course> Courses, int TotalCount)> SearchCoursesAsync(string searchTerm, int pageNumber, int pageSize, CourseLevel? level = null, Guid? categoryId = null, CancellationToken cancellationToken = default);
    Task<double> GetCourseRatingAsync(Guid courseId, CancellationToken cancellationToken = default);
}

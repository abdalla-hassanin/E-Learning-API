using ELearningApi.Data.Entities;
using ELearningApi.Data.Enums;
using ELearningApi.Infrustructure.Base;
using ELearningApi.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace ELearningApi.Service.Service;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Course> CreateCourseAsync(Course course, CancellationToken cancellationToken = default)
    {
        if (course == null)
            throw new ArgumentNullException(nameof(course));

        await _unitOfWork.Repository<Course>().AddAsync(course, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return course;
    }

    public async Task<Course> GetCourseByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var courseSpec = new Specification<Course>(c => c.Id == id)
            .AddInclude(c => c.Include(x => x.Instructor))
            .AddInclude(c => c.Include(x => x.Category))
            .AddInclude(c => c.Include(x => x.Sections).ThenInclude(s => s.Lectures));

        var courses = await _unitOfWork.Repository<Course>().FindBySpecificationAsync(courseSpec, cancellationToken);
        var course = courses.FirstOrDefault();

        if (course == null)
        {
            throw new KeyNotFoundException($"Course with ID {id} not found.");
        }

        return course;
    }

    public async Task<Course> UpdateCourseAsync(Course course, CancellationToken cancellationToken = default)
    {
        if (course == null)
            throw new ArgumentNullException(nameof(course));

        course.UpdatedAt = DateTime.UtcNow;
        await _unitOfWork.Repository<Course>().UpdateAsync(course, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return course;
    }

    public async Task DeleteCourseAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var course = await GetCourseByIdAsync(id, cancellationToken);
        if (course == null)
            throw new KeyNotFoundException($"Course with ID {id} not found.");

        await _unitOfWork.Repository<Course>().RemoveAsync(course, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);
    }

    public async Task<IEnumerable<Course>> GetCoursesByCategoryAsync(Guid categoryId,
        CancellationToken cancellationToken = default)
    {
        var spec = new Specification<Course>(c => c.CategoryId == categoryId)
            .AddInclude(c => c.Include(x => x.Instructor))
            .ApplyOrderBy(q => q.OrderByDescending(c => c.CreatedAt));

        return await _unitOfWork.Repository<Course>().FindBySpecificationAsync(spec, cancellationToken);
    }

    public async Task<IEnumerable<Course>> GetCoursesByInstructorAsync(Guid instructorId,
        CancellationToken cancellationToken = default)
    {
        var spec = new Specification<Course>(c => c.InstructorId == instructorId)
            .AddInclude(c => c.Include(x => x.Category))
            .ApplyOrderBy(q => q.OrderByDescending(c => c.CreatedAt));

        return await _unitOfWork.Repository<Course>().FindBySpecificationAsync(spec, cancellationToken);
    }

    public async Task<(IEnumerable<Course> Courses, int TotalCount)> SearchCoursesAsync(
        string searchTerm,
        int pageNumber,
        int pageSize,
        CourseLevel? level = null,
        Guid? categoryId = null,
        CancellationToken cancellationToken = default)
    {
        var spec = new Specification<Course>(c =>
            (string.IsNullOrEmpty(searchTerm) || c.Title.Contains(searchTerm) || c.Description.Contains(searchTerm)) &&
            (!level.HasValue || c.Level == level.Value) &&
            (!categoryId.HasValue || c.CategoryId == categoryId.Value));

        spec.AddInclude(c => c.Include(x => x.Instructor))
            .AddInclude(c => c.Include(x => x.Category))
            .ApplyOrderBy(q => q.OrderByDescending(c => c.CreatedAt))
            .ApplyPaging((pageNumber - 1) * pageSize, pageSize);

        var courses = await _unitOfWork.Repository<Course>().FindBySpecificationAsync(spec, cancellationToken);
        var totalCount = await _unitOfWork.Repository<Course>().CountAsync(spec.Criteria, cancellationToken);

        return (courses, totalCount);
    }

    public async Task<double> GetCourseRatingAsync(Guid courseId, CancellationToken cancellationToken = default)
    {
        var reviewsSpec = new Specification<Review>(r => r.CourseId == courseId)
            .ApplyOrderBy(q => q.OrderBy(r => r.Id)); // Ensure consistent ordering

        var reviews = await _unitOfWork.Repository<Review>().FindBySpecificationAsync(reviewsSpec, cancellationToken);

        var reviewsList = reviews.ToList(); // Materialize the query results

        if (reviewsList.Count == 0)
            return 0;

        return reviewsList.Average(r => r.Rating);
    }
}
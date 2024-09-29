using ELearningApi.Data.Entities;
using ELearningApi.Data.Enums;
using ELearningApi.Infrustructure.Base;
using ELearningApi.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace ELearningApi.Service.Service;

public class SearchService : ISearchService
{
    private readonly IUnitOfWork _unitOfWork;

    public SearchService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<IEnumerable<Course>> SearchCoursesAsync(
        string searchTerm,
        CourseLevel? level = null,
        Guid? categoryId = null,
        decimal? minPrice = null,
        decimal? maxPrice = null,
        CancellationToken cancellationToken = default)
    {
        var courseRepo = _unitOfWork.Repository<Course>();

        var specification = new Specification<Course>(c =>
            (string.IsNullOrEmpty(searchTerm) || c.Title.Contains(searchTerm) || c.Description.Contains(searchTerm)) &&
            (!level.HasValue || c.Level == level.Value) &&
            (!categoryId.HasValue || c.CategoryId == categoryId.Value) &&
            (!minPrice.HasValue || c.Price >= minPrice.Value) &&
            (!maxPrice.HasValue || c.Price <= maxPrice.Value)
        );

        specification.AddInclude(q => q.Include(c => c.Instructor).Include(c => c.Category));
        specification.ApplyOrderBy(q => q.OrderByDescending(c => c.CreatedAt));

        return await courseRepo.FindBySpecificationAsync(specification, cancellationToken);
    }

    public async Task<IEnumerable<Instructor>> SearchInstructorsAsync(
        string searchTerm,
        string? expertise = null,
        CancellationToken cancellationToken = default)
    {
        var instructorRepo = _unitOfWork.Repository<Instructor>();

        var specification = new Specification<Instructor>(i =>
            (string.IsNullOrEmpty(searchTerm) || i.ApplicationUser.UserName!.Contains(searchTerm) ||
             i.Biography.Contains(searchTerm)) &&
            (string.IsNullOrEmpty(expertise) || i.Expertise.Contains(expertise))
        );

        specification.AddInclude(q => q.Include(i => i.Courses));
        specification.ApplyOrderBy(q => q.OrderByDescending(i => i.ApplicationUser.CreatedAt));

        return await instructorRepo.FindBySpecificationAsync(specification, cancellationToken);
    }

    public async Task<IEnumerable<Lecture>> SearchLecturesAsync(
        string searchTerm,
        Guid? courseId = null,
        CancellationToken cancellationToken = default)
    {
        var lectureRepo = _unitOfWork.Repository<Lecture>();

        var specification = new Specification<Lecture>(l =>
            (string.IsNullOrEmpty(searchTerm) || l.Title.Contains(searchTerm) || l.Description.Contains(searchTerm) ||
             l.Content.Contains(searchTerm)) &&
            (!courseId.HasValue || l.Section.CourseId == courseId.Value)
        );

        specification.AddInclude(q => q.Include(l => l.Section).ThenInclude(s => s.Course));
        specification.ApplyOrderBy(q => q.OrderBy(l => l.Section.OrderIndex).ThenBy(l => l.OrderIndex));

        return await lectureRepo.FindBySpecificationAsync(specification, cancellationToken);
    }


    public async Task<(IEnumerable<Course> Courses, IEnumerable<Instructor> Instructors, IEnumerable<Lecture> Lectures)>
        PerformGlobalSearchAsync(
            string searchTerm,
            CancellationToken cancellationToken = default)
    {
        var courses = await SearchCoursesAsync(searchTerm, cancellationToken: cancellationToken);
        var instructors = await SearchInstructorsAsync(searchTerm, cancellationToken: cancellationToken);
        var lectures = await SearchLecturesAsync(searchTerm, cancellationToken: cancellationToken);
        return (courses, instructors, lectures);
    }
}
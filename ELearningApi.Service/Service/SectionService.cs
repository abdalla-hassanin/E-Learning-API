using ELearningApi.Data.Entities;
using ELearningApi.Infrustructure.Base;
using ELearningApi.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace ELearningApi.Service.Service;

public class SectionService : ISectionService
{
    private readonly IUnitOfWork _unitOfWork;

    public SectionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Section> CreateSectionAsync(Section section, CancellationToken cancellationToken = default)
    {
        if (section == null)
            throw new ArgumentNullException(nameof(section));

        await ValidateCourseExistsAsync(section.CourseId, cancellationToken);

        // Set the order index to be the last in the course
        var lastOrderIndex = await GetLastOrderIndexForCourseAsync(section.CourseId, cancellationToken);
        section.OrderIndex = lastOrderIndex + 1;

        await _unitOfWork.Repository<Section>().AddAsync(section, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return section;
    }

    public async Task<Section> GetSectionByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sections = await _unitOfWork.Repository<Section>().FindAsync(
            s => s.Id == id,
            include: query => query.Include(s => s.Lectures).Include(s => s.Quizzes),
            cancellationToken: cancellationToken
        );

        var section = sections.FirstOrDefault();

        if (section == null)
            throw new KeyNotFoundException($"Section with ID {id} not found.");

        return section;
    }

    public async Task<Section> UpdateSectionAsync(Section section, CancellationToken cancellationToken = default)
    {
        if (section == null)
            throw new ArgumentNullException(nameof(section));

        var existingSection = await GetSectionByIdAsync(section.Id, cancellationToken);

        existingSection.Title = section.Title;
        existingSection.Description = section.Description;
        existingSection.OrderIndex = section.OrderIndex;
        // Add any other properties that need updating

        await _unitOfWork.Repository<Section>().UpdateAsync(existingSection, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return existingSection;
    }

    public async Task DeleteSectionAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var section = await GetSectionByIdAsync(id, cancellationToken);

        if (section.Lectures.Any() || section.Quizzes.Any())
            throw new InvalidOperationException("Cannot delete a section that has associated lectures or quizzes.");

        await _unitOfWork.Repository<Section>().RemoveAsync(section, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        // Reorder remaining sections
        await ReorderSectionsAfterDeletionAsync(section.CourseId, section.OrderIndex, cancellationToken);
    }

    public async Task<IEnumerable<Section>> GetSectionsForCourseAsync(Guid courseId,
        CancellationToken cancellationToken = default)
    {
        await ValidateCourseExistsAsync(courseId, cancellationToken);

        var sections = await _unitOfWork.Repository<Section>().FindAsync(
            s => s.CourseId == courseId,
            include: query => query.Include(s => s.Lectures).Include(s => s.Quizzes),
            cancellationToken: cancellationToken
        );

        return sections.OrderBy(s => s.OrderIndex);
    }

    private async Task ValidateCourseExistsAsync(Guid courseId, CancellationToken cancellationToken)
    {
        var courseExists = await _unitOfWork.Repository<Course>().AnyAsync(c => c.Id == courseId, cancellationToken);
        if (!courseExists)
            throw new KeyNotFoundException($"Course with ID {courseId} not found.");
    }

    private async Task<int> GetLastOrderIndexForCourseAsync(Guid courseId, CancellationToken cancellationToken)
    {
        var maxOrderIndex = await _unitOfWork.Repository<Section>()
            .Find(s => s.CourseId == courseId)
            .MaxAsync(s => (int?)s.OrderIndex, cancellationToken);

        return maxOrderIndex ?? 0;
    }

    private async Task ReorderSectionsAfterDeletionAsync(Guid courseId, int deletedOrderIndex,
        CancellationToken cancellationToken)
    {
        var sectionsToReorder = await _unitOfWork.Repository<Section>().FindAsync(
            s => s.CourseId == courseId && s.OrderIndex > deletedOrderIndex,
            cancellationToken: cancellationToken
        );

        foreach (var section in sectionsToReorder)
        {
            section.OrderIndex--;
            await _unitOfWork.Repository<Section>().UpdateAsync(section, cancellationToken);
        }

        await _unitOfWork.CompleteAsync(cancellationToken);
    }
}
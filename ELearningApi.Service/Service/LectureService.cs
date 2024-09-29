using ELearningApi.Data.Entities;
using ELearningApi.Infrustructure.Base;
using ELearningApi.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace ELearningApi.Service.Service;

public class LectureService : ILectureService
{
    private readonly IUnitOfWork _unitOfWork;

    public LectureService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Lecture> CreateLectureAsync(Lecture lecture, CancellationToken cancellationToken = default)
    {
        if (lecture == null)
            throw new ArgumentNullException(nameof(lecture));

        await ValidateSectionExistsAsync(lecture.SectionId, cancellationToken);

        // Set the order index to be the last in the section
        var lastOrderIndex = await GetLastOrderIndexForSectionAsync(lecture.SectionId, cancellationToken);
        lecture.OrderIndex = lastOrderIndex + 1;

        await _unitOfWork.Repository<Lecture>().AddAsync(lecture, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return lecture;
    }

    public async Task<Lecture> GetLectureByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var lectures = await _unitOfWork.Repository<Lecture>().FindAsync(
            l => l.Id == id,
            include: query => query.Include(l => l.Resources),
            cancellationToken: cancellationToken
        );

        var lecture = lectures.FirstOrDefault();

        if (lecture == null)
            throw new KeyNotFoundException($"Lecture with ID {id} not found.");

        return lecture;
    }

    public async Task<Lecture> UpdateLectureAsync(Lecture lecture, CancellationToken cancellationToken = default)
    {
        if (lecture == null)
            throw new ArgumentNullException(nameof(lecture));

        var existingLecture = await GetLectureByIdAsync(lecture.Id, cancellationToken);

        existingLecture.Title = lecture.Title;
        existingLecture.Description = lecture.Description;
        existingLecture.Content = lecture.Content;
        existingLecture.Duration = lecture.Duration;
        existingLecture.OrderIndex = lecture.OrderIndex;
        existingLecture.Type = lecture.Type;
        existingLecture.VideoUrl = lecture.VideoUrl;
        // Update other properties as needed

        await _unitOfWork.Repository<Lecture>().UpdateAsync(existingLecture, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return existingLecture;
    }

    public async Task DeleteLectureAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var lecture = await GetLectureByIdAsync(id, cancellationToken);

        // Remove associated resources
        foreach (var resource in lecture.Resources)
        {
            await _unitOfWork.Repository<LectureResource>().RemoveAsync(resource, cancellationToken);
        }

        await _unitOfWork.Repository<Lecture>().RemoveAsync(lecture, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        // Reorder remaining lectures
        await ReorderLecturesAfterDeletionAsync(lecture.SectionId, lecture.OrderIndex, cancellationToken);
    }

    public async Task<IEnumerable<Lecture>> GetLecturesForSectionAsync(Guid sectionId,
        CancellationToken cancellationToken = default)
    {
        await ValidateSectionExistsAsync(sectionId, cancellationToken);

        var lectures = await _unitOfWork.Repository<Lecture>().FindAsync(
            l => l.SectionId == sectionId,
            include: query => query.Include(l => l.Resources),
            cancellationToken: cancellationToken
        );

        return lectures.OrderBy(l => l.OrderIndex);
    }

    public async Task<Lecture> AddResourceToLectureAsync(Guid lectureId, LectureResource resource, CancellationToken cancellationToken = default)
    {
        var lecture = await GetLectureByIdAsync(lectureId, cancellationToken);
        if (lecture == null)
            throw new KeyNotFoundException($"Lecture with ID {lectureId} not found.");

        lecture.Resources.Add(resource);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return lecture;
    }

    public async Task<Lecture> RemoveResourceFromLectureAsync(Guid lectureId, Guid resourceId, CancellationToken cancellationToken = default)
    {
        var lecture = await GetLectureByIdAsync(lectureId, cancellationToken);
        if (lecture == null)
            throw new KeyNotFoundException($"Lecture with ID {lectureId} not found.");

        var resource = lecture.Resources.FirstOrDefault(r => r.Id == resourceId);
        if (resource == null)
            throw new KeyNotFoundException($"Resource with ID {resourceId} not found in lecture {lectureId}.");

        lecture.Resources.Remove(resource);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return lecture;
    }

    private async Task ValidateSectionExistsAsync(Guid sectionId, CancellationToken cancellationToken)
    {
        var sectionExists = await _unitOfWork.Repository<Section>().AnyAsync(s => s.Id == sectionId, cancellationToken);
        if (!sectionExists)
            throw new KeyNotFoundException($"Section with ID {sectionId} not found.");
    }

    private async Task<int> GetLastOrderIndexForSectionAsync(Guid sectionId, CancellationToken cancellationToken)
    {
        var maxOrderIndex = await _unitOfWork.Repository<Lecture>()
            .Find(l => l.SectionId == sectionId)
            .MaxAsync(l => (int?)l.OrderIndex, cancellationToken);

        return maxOrderIndex ?? 0;
    }

    private async Task ReorderLecturesAfterDeletionAsync(Guid sectionId, int deletedOrderIndex,
        CancellationToken cancellationToken)
    {
        var lecturesToReorder = await _unitOfWork.Repository<Lecture>().FindAsync(
            l => l.SectionId == sectionId && l.OrderIndex > deletedOrderIndex,
            cancellationToken: cancellationToken
        );

        foreach (var lecture in lecturesToReorder)
        {
            lecture.OrderIndex--;
            await _unitOfWork.Repository<Lecture>().UpdateAsync(lecture, cancellationToken);
        }

        await _unitOfWork.CompleteAsync(cancellationToken);
    }
}
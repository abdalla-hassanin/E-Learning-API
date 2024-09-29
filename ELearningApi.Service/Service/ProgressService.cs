using ELearningApi.Data.Entities;
using ELearningApi.Data.Enums;
using ELearningApi.Infrustructure.Base;
using ELearningApi.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace ELearningApi.Service.Service;

public class ProgressService : IProgressService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProgressService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Progress> UpdateProgressAsync(Guid enrollmentId, Guid lectureId, decimal progressPercentage,
        ProgressStatus status)
    {
        var progressRepository = _unitOfWork.Repository<Progress>();
        var progress = await progressRepository.Find(p => p.EnrollmentId == enrollmentId && p.LectureId == lectureId)
            .FirstOrDefaultAsync();

        if (progress == null)
        {
            progress = new Progress
            {
                EnrollmentId = enrollmentId,
                LectureId = lectureId,
                StartedAt = DateTime.UtcNow
            };
            await progressRepository.AddAsync(progress);
        }

        progress.ProgressPercentage = progressPercentage;
        progress.Status = status;

        if (status == ProgressStatus.Completed && !progress.CompletedAt.HasValue)
        {
            progress.CompletedAt = DateTime.UtcNow;
        }

        await _unitOfWork.CompleteAsync();
        return progress;
    }

    public async Task<decimal> GetProgressForEnrollmentAsync(Guid enrollmentId)
    {
        var enrollment = await _unitOfWork.Repository<Enrollment>()
            .Find(e => e.Id == enrollmentId)
            .Include(e => e.Course)
            .ThenInclude(c => c.Sections)
            .ThenInclude(s => s.Lectures)
            .FirstOrDefaultAsync();

        if (enrollment == null)
        {
            throw new ArgumentException("Enrollment not found", nameof(enrollmentId));
        }

        var totalLectures = enrollment.Course.Sections.SelectMany(s => s.Lectures).Count();
        var completedLectures = await _unitOfWork.Repository<Progress>()
            .CountAsync(p => p.EnrollmentId == enrollmentId && p.Status == ProgressStatus.Completed);

        return totalLectures > 0 ? (decimal)completedLectures / totalLectures * 100 : 0;
    }

    public async Task<decimal> GetOverallCourseProgressAsync(Guid studentId, Guid courseId)
    {
        var enrollment = await _unitOfWork.Repository<Enrollment>()
            .Find(e => e.StudentId == studentId && e.CourseId == courseId)
            .FirstOrDefaultAsync();

        if (enrollment == null)
        {
            throw new ArgumentException("Student is not enrolled in the course");
        }

        return await GetProgressForEnrollmentAsync(enrollment.Id);
    }

    public async Task<Progress> MarkLectureAsCompleteAsync(Guid enrollmentId, Guid lectureId)
    {
        return await UpdateProgressAsync(enrollmentId, lectureId, 100, ProgressStatus.Completed);
    }

    public async Task<IEnumerable<Lecture>> GetCompletedLecturesAsync(Guid studentId, Guid courseId)
    {
        var enrollment = await _unitOfWork.Repository<Enrollment>()
            .Find(e => e.StudentId == studentId && e.CourseId == courseId)
            .FirstOrDefaultAsync();

        if (enrollment == null)
        {
            throw new ArgumentException("Student is not enrolled in the course");
        }

        var completedProgresses = await _unitOfWork.Repository<Progress>()
            .Find(p => p.EnrollmentId == enrollment.Id && p.Status == ProgressStatus.Completed)
            .Include(p => p.Lecture)
            .ToListAsync();

        return completedProgresses.Select(p => p.Lecture);
    }

    public async Task<IEnumerable<Progress>> GetProgressDetailsForEnrollmentAsync(Guid enrollmentId)
    {
        return await _unitOfWork.Repository<Progress>()
            .Find(p => p.EnrollmentId == enrollmentId)
            .Include(p => p.Lecture)
            .OrderBy(p => p.Lecture.OrderIndex)
            .ToListAsync();
    }

    public async Task<bool> IsLectureCompletedAsync(Guid enrollmentId, Guid lectureId)
    {
        var progress = await _unitOfWork.Repository<Progress>()
            .Find(p => p.EnrollmentId == enrollmentId && p.LectureId == lectureId)
            .FirstOrDefaultAsync();

        return progress?.Status == ProgressStatus.Completed;
    }

    public async Task ResetProgressForEnrollmentAsync(Guid enrollmentId)
    {
        var progressRepository = _unitOfWork.Repository<Progress>();
        var progresses = await progressRepository.Find(p => p.EnrollmentId == enrollmentId).ToListAsync();

        foreach (var progress in progresses)
        {
            progress.ProgressPercentage = 0;
            progress.Status = ProgressStatus.NotStarted;
            progress.StartedAt = null;
            progress.CompletedAt = null;
        }

        await _unitOfWork.CompleteAsync();
    }
    
}
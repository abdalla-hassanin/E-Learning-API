using ELearningApi.Data.Entities;

namespace ELearningApi.Service.IService;

public interface ILectureService
{
    Task<Lecture> CreateLectureAsync(Lecture lecture, CancellationToken cancellationToken = default);
    Task<Lecture> GetLectureByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Lecture> UpdateLectureAsync(Lecture lecture, CancellationToken cancellationToken = default);
    Task DeleteLectureAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Lecture>> GetLecturesForSectionAsync(Guid sectionId, CancellationToken cancellationToken = default);
    Task<Lecture> AddResourceToLectureAsync(Guid lectureId, LectureResource resource, CancellationToken cancellationToken = default);
    Task<Lecture> RemoveResourceFromLectureAsync(Guid lectureId, Guid resourceId, CancellationToken cancellationToken = default);

}

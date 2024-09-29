using ELearningApi.Data.Entities;

namespace ELearningApi.Service.IService;

public interface IReviewService
{
    Task<Review> CreateReviewAsync(Review review, CancellationToken cancellationToken = default);
    Task<Review> GetReviewByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Review> UpdateReviewAsync(Review review, CancellationToken cancellationToken = default);
    Task DeleteReviewAsync(Guid id, CancellationToken cancellationToken = default);
    Task<(IEnumerable<Review> Reviews, int TotalCount)> GetReviewsForCourseAsync(Guid courseId, int page = 1, int pageSize = 10, CancellationToken cancellationToken = default);
    Task<decimal> CalculateAverageRatingAsync(Guid courseId, CancellationToken cancellationToken = default);
}
using ELearningApi.Data.Entities;
using ELearningApi.Infrustructure.Base;
using ELearningApi.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace ELearningApi.Service.Service;

public class ReviewService : IReviewService
{
    private readonly IUnitOfWork _unitOfWork;

    public ReviewService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Review> CreateReviewAsync(Review review, CancellationToken cancellationToken = default)
    {
        if (review == null)
            throw new ArgumentNullException(nameof(review));

        await _unitOfWork.Repository<Review>().AddAsync(review, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return review;
    }

    public async Task<Review> GetReviewByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var reviews = await _unitOfWork.Repository<Review>().FindAsync(
            r => r.Id == id,
            include: q => q.Include(r => r.Student).Include(r => r.Course),
            cancellationToken: cancellationToken
        );

        var review = reviews.FirstOrDefault();

        if (review == null)
            throw new KeyNotFoundException($"Review with ID {id} not found.");

        return review;
    }

    public async Task<Review> UpdateReviewAsync(Review review, CancellationToken cancellationToken = default)
    {
        if (review == null)
            throw new ArgumentNullException(nameof(review));

        var existingReview = await GetReviewByIdAsync(review.Id, cancellationToken);

        existingReview.Rating = review.Rating;
        existingReview.Comment = review.Comment;
        existingReview.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.Repository<Review>().UpdateAsync(existingReview, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return existingReview;
    }

    public async Task DeleteReviewAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var review = await GetReviewByIdAsync(id, cancellationToken);

        await _unitOfWork.Repository<Review>().RemoveAsync(review, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);
    }

    public async Task<(IEnumerable<Review> Reviews, int TotalCount)> GetReviewsForCourseAsync(Guid courseId, int page = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var (reviews, totalCount) = await _unitOfWork.Repository<Review>().GetPagedAsync(
            r => r.CourseId == courseId,
            page,
            pageSize,
            orderBy: q => q.OrderByDescending(r => r.CreatedAt),
            include: q => q.Include(r => r.Student),
            cancellationToken: cancellationToken
        );

        return (reviews, totalCount);
    }

    public async Task<decimal> CalculateAverageRatingAsync(Guid courseId, CancellationToken cancellationToken = default)
    {
        var reviews = await _unitOfWork.Repository<Review>().FindAsync(
            r => r.CourseId == courseId,
            cancellationToken: cancellationToken
        );

        var reviewsList = reviews.ToList();

        if (!reviewsList.Any())
            return 0;

        return (decimal)reviewsList.Average(r => r.Rating);
    }
}

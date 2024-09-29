using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Review.Commands.CreateReview;

public class CreateReviewCommand : IRequest<ApiResponse<ReviewDto>>
{
    public int Rating { get; set; }
    public string Comment { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
}


using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Review.Commands.UpdateReview;

public class UpdateReviewCommand : IRequest<ApiResponse<ReviewDto>>
{
    public Guid Id { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
}

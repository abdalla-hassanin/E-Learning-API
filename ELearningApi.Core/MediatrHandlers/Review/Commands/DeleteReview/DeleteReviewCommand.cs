using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Review.Commands.DeleteReview;

public class DeleteReviewCommand : IRequest<ApiResponse<string>>
{
    public Guid Id { get; set; }
}

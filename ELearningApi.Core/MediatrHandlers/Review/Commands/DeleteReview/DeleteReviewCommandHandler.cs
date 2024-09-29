using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Review.Commands.DeleteReview;

public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, ApiResponse<string>>
{
    private readonly IReviewService _reviewService;
    private readonly ApiResponseHandler _responseHandler;

    public DeleteReviewCommandHandler(IReviewService reviewService, ApiResponseHandler responseHandler)
    {
        _reviewService = reviewService;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<string>> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        await _reviewService.DeleteReviewAsync(request.Id, cancellationToken);
        return _responseHandler.Success( "Review deleted successfully.");
    }
}

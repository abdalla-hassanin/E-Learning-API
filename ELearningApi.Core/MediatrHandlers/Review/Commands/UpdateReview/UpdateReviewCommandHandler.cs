using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Review.Commands.UpdateReview;

public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, ApiResponse<ReviewDto>>
{
    private readonly IReviewService _reviewService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public UpdateReviewCommandHandler(IReviewService reviewService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _reviewService = reviewService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<ReviewDto>> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var existingReview = await _reviewService.GetReviewByIdAsync(request.Id, cancellationToken);
        if (existingReview == null)
        {
            return _responseHandler.NotFound<ReviewDto>($"Review with ID {request.Id} not found.");
        }

        _mapper.Map(request, existingReview);
        var updatedReview = await _reviewService.UpdateReviewAsync(existingReview, cancellationToken);
        var reviewDto = _mapper.Map<ReviewDto>(updatedReview);
        return _responseHandler.Success(reviewDto);
    }
}


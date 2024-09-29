using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Review.Commands.CreateReview;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, ApiResponse<ReviewDto>>
{
    private readonly IReviewService _reviewService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public CreateReviewCommandHandler(IReviewService reviewService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _reviewService = reviewService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<ReviewDto>> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = _mapper.Map<Data.Entities.Review>(request);
        var createdReview = await _reviewService.CreateReviewAsync(review, cancellationToken);
        var reviewDto = _mapper.Map<ReviewDto>(createdReview);
        return _responseHandler.Created(reviewDto);
    }
}

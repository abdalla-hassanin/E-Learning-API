using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Review.Queries.GetReviewById;

public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, ApiResponse<ReviewDto>>
{
    private readonly IReviewService _reviewService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetReviewByIdQueryHandler(IReviewService reviewService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _reviewService = reviewService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<ReviewDto>> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
    {
        var review = await _reviewService.GetReviewByIdAsync(request.Id, cancellationToken);
        if (review == null)
        {
            return _responseHandler.NotFound<ReviewDto>($"Review with ID {request.Id} not found.");
        }

        var reviewDto = _mapper.Map<ReviewDto>(review);
        return _responseHandler.Success(reviewDto);
    }
}


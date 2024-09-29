using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Lecture.Command.DeleteLecture;

public class DeleteLectureCommandHandler : IRequestHandler<DeleteLectureCommand, ApiResponse<string>>
{
    private readonly ILectureService _lectureService;
    private readonly ApiResponseHandler _responseHandler;

    public DeleteLectureCommandHandler(ILectureService lectureService, ApiResponseHandler responseHandler)
    {
        _lectureService = lectureService ?? throw new ArgumentNullException(nameof(lectureService));
        _responseHandler = responseHandler ?? throw new ArgumentNullException(nameof(responseHandler));
    }

    public async Task<ApiResponse<string>> Handle(DeleteLectureCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _lectureService.DeleteLectureAsync(request.Id, cancellationToken);
            return _responseHandler.Success( "Lecture deleted successfully.");
        }
        catch (KeyNotFoundException)
        {
            return _responseHandler.NotFound<string>($"Lecture with ID {request.Id} not found.");
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest<string>($"Failed to delete lecture: {ex.Message}");
        }
    }
}

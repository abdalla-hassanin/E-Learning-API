using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Section.Commands.DeleteSection;

public class DeleteSectionCommandHandler : IRequestHandler<DeleteSectionCommand, ApiResponse<string>>
{
    private readonly ISectionService _sectionService;
    private readonly ApiResponseHandler _responseHandler;

    public DeleteSectionCommandHandler(ISectionService sectionService, ApiResponseHandler responseHandler)
    {
        _sectionService = sectionService;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<string>> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _sectionService.DeleteSectionAsync(request.Id, cancellationToken);
            return _responseHandler.Success("Section deleted successfully.");
        }
        catch (KeyNotFoundException)
        {
            return _responseHandler.NotFound<string>($"Section with ID {request.Id} not found.");
        }
        catch (InvalidOperationException ex)
        {
            return _responseHandler.BadRequest<string>(ex.Message);
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest<string>($"Failed to delete section: {ex.Message}");
        }
    }
}
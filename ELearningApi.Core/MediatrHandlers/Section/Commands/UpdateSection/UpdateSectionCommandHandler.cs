using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Section.Commands.UpdateSection;

public class UpdateSectionCommandHandler : IRequestHandler<UpdateSectionCommand, ApiResponse<SectionDto>>
{
    private readonly ISectionService _sectionService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public UpdateSectionCommandHandler(ISectionService sectionService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _sectionService = sectionService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<SectionDto>> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var section = _mapper.Map<Data.Entities.Section>(request);
            var updatedSection = await _sectionService.UpdateSectionAsync(section, cancellationToken);
            var sectionDto = _mapper.Map<SectionDto>(updatedSection);
            return _responseHandler.Success(sectionDto, "Section updated successfully.");
        }
        catch (KeyNotFoundException)
        {
            return _responseHandler.NotFound<SectionDto>($"Section with ID {request.Id} not found.");
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest<SectionDto>($"Failed to update section: {ex.Message}");
        }
    }
}

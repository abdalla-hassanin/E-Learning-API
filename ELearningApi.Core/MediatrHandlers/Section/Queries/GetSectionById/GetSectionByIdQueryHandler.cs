using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Section.Queries.GetSectionById;

public class GetSectionByIdQueryHandler : IRequestHandler<GetSectionByIdQuery, ApiResponse<SectionDto>>
{
    private readonly ISectionService _sectionService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetSectionByIdQueryHandler(ISectionService sectionService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _sectionService = sectionService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<SectionDto>> Handle(GetSectionByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var section = await _sectionService.GetSectionByIdAsync(request.Id, cancellationToken);
            var sectionDto = _mapper.Map<SectionDto>(section);
            return _responseHandler.Success(sectionDto);
        }
        catch (KeyNotFoundException)
        {
            return _responseHandler.NotFound<SectionDto>($"Section with ID {request.Id} not found.");
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest<SectionDto>($"Failed to retrieve section: {ex.Message}");
        }
    }
}


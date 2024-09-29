using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Section.Commands.CreateSection;

public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, ApiResponse<SectionDto>>
{
    private readonly ISectionService _sectionService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public CreateSectionCommandHandler(ISectionService sectionService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _sectionService = sectionService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<SectionDto>> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var section = _mapper.Map<Data.Entities.Section>(request);
            var createdSection = await _sectionService.CreateSectionAsync(section, cancellationToken);
            var sectionDto = _mapper.Map<SectionDto>(createdSection);
            return _responseHandler.Success(sectionDto, "Section created successfully.");
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest<SectionDto>($"Failed to create section: {ex.Message}");
        }
    }
}

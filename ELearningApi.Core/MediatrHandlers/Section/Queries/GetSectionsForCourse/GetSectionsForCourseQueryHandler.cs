using AutoMapper;
using ELearningApi.Core.Base.ApiResponse;
using ELearningApi.Service.IService;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Section.Queries.GetSectionsForCourse;

public class GetSectionsForCourseQueryHandler : IRequestHandler<GetSectionsForCourseQuery, ApiResponse<IEnumerable<SectionDto>>>
{
    private readonly ISectionService _sectionService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public GetSectionsForCourseQueryHandler(ISectionService sectionService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _sectionService = sectionService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<IEnumerable<SectionDto>>> Handle(GetSectionsForCourseQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var sections = await _sectionService.GetSectionsForCourseAsync(request.CourseId, cancellationToken);
            var sectionDtos = _mapper.Map<IEnumerable<SectionDto>>(sections);
            return _responseHandler.Success(sectionDtos);
        }
        catch (KeyNotFoundException)
        {
            return _responseHandler.NotFound<IEnumerable<SectionDto>>($"Course with ID {request.CourseId} not found.");
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest<IEnumerable<SectionDto>>($"Failed to retrieve sections: {ex.Message}");
        }
    }
}


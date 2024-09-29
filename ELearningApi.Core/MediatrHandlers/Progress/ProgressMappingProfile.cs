using AutoMapper;

namespace ELearningApi.Core.MediatrHandlers.Progress;

public class ProgressMappingProfile : Profile
{
    public ProgressMappingProfile()
    {
        CreateMap<Data.Entities.Progress, ProgressDto>().ReverseMap();
    }
}

using AutoMapper;
using ELearningApi.Core.MediatrHandlers.Section.Commands.CreateSection;
using ELearningApi.Core.MediatrHandlers.Section.Commands.UpdateSection;

namespace ELearningApi.Core.MediatrHandlers.Section;

public class SectionMappingProfile : Profile
{
    public SectionMappingProfile()
    {
        CreateMap<CreateSectionCommand, Data.Entities.Section>();
        CreateMap<UpdateSectionCommand, Data.Entities.Section>();
        CreateMap<Data.Entities.Section, SectionDto>();
    }
}
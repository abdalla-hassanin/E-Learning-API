using AutoMapper;

namespace ELearningApi.Core.MediatrHandlers.Enrollment;

public class EnrollmentMappingProfile : Profile
{
    public EnrollmentMappingProfile()
    {
        CreateMap<Data.Entities.Enrollment, EnrollmentDto>();
    }
}

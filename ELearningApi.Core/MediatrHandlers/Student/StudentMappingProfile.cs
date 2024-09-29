using AutoMapper;
using ELearningApi.Core.MediatrHandlers.Student.Commands.UpdateStudent;

namespace ELearningApi.Core.MediatrHandlers.Student;

public class StudentMappingProfile : Profile
{
    public StudentMappingProfile()
    {
        // Entity to DTO
        CreateMap<Data.Entities.Student, StudentDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.ApplicationUser.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.ApplicationUser.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ApplicationUser.Email));


        // UpdateStudentCommand to Student
        CreateMap<UpdateStudentCommand, Data.Entities.Student>()
            .ForPath(dest => dest.ApplicationUser.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForPath(dest => dest.ApplicationUser.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForPath(dest => dest.ApplicationUser.Email, opt => opt.MapFrom(src => src.Email));
    }
}

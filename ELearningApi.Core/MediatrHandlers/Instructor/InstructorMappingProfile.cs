using AutoMapper;
using ELearningApi.Core.MediatrHandlers.Instructor.Commands.UpdateInstructor;

namespace ELearningApi.Core.MediatrHandlers.Instructor;

    public class InstructorMappingProfile : Profile
    {
        public InstructorMappingProfile()
        {
            // Entity to DTO
            CreateMap<Data.Entities.Instructor, InstructorDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.ApplicationUser.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.ApplicationUser.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ApplicationUser.Email));


            // UpdateInstructorCommand to Instructor
            CreateMap<UpdateInstructorCommand, Data.Entities.Instructor>()
                .ForPath(dest => dest.ApplicationUser.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForPath(dest => dest.ApplicationUser.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForPath(dest => dest.ApplicationUser.Email, opt => opt.MapFrom(src => src.Email));
        }
    }

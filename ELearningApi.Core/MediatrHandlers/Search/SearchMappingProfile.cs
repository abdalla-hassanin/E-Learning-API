using AutoMapper;
using ELearningApi.Core.MediatrHandlers.Search.Dtos;
using ELearningApi.Data.Entities;

namespace ELearningApi.Core.MediatrHandlers.Search;

public class SearchMappingProfile : Profile
{
    public SearchMappingProfile()
    {
        CreateMap<Data.Entities.Course, CourseDto>()
            .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => src.Instructor.ApplicationUser.UserName))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<Data.Entities.Instructor, InstructorDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ApplicationUser.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ApplicationUser.Email));

        CreateMap<Data.Entities.Lecture, LectureDto>()
            .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Section.Course.Title))
            .ForMember(dest => dest.SectionName, opt => opt.MapFrom(src => src.Section.Title));
    }
}


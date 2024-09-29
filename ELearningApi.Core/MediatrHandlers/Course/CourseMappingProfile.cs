using AutoMapper;
using ELearningApi.Core.MediatrHandlers.Course.Commands.CreateCourse;
using ELearningApi.Core.MediatrHandlers.Course.Commands.UpdateCourse;

namespace ELearningApi.Core.MediatrHandlers.Course;

public class CourseMappingProfile : Profile
{
    public CourseMappingProfile()
    {
        CreateMap<CreateCourseCommand, Data.Entities.Course>();
        CreateMap<UpdateCourseCommand, Data.Entities.Course>();
        CreateMap<Data.Entities.Course, CourseDto>().ReverseMap();
    }
}
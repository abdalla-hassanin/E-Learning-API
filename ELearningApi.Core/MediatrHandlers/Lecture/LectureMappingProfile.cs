using AutoMapper;
using ELearningApi.Core.MediatrHandlers.Lecture.Command.AddResourceToLecture;
using ELearningApi.Core.MediatrHandlers.Lecture.Command.CreateLecture;
using ELearningApi.Core.MediatrHandlers.Lecture.Command.UpdateLecture;
using ELearningApi.Data.Entities;

namespace ELearningApi.Core.MediatrHandlers.Lecture;

public class LectureMappingProfile : Profile
{
    public LectureMappingProfile()
    {
        CreateMap<Data.Entities.Lecture, LectureDto>();
        CreateMap<LectureResource, LectureResourceDto>();
        CreateMap<CreateLectureCommand, Data.Entities.Lecture>();
        CreateMap<UpdateLectureCommand, Data.Entities.Lecture>();
        CreateMap<AddResourceToLectureCommand, LectureResource>();
    }
}
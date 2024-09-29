using AutoMapper;
using ELearningApi.Core.MediatrHandlers.Quiz.Commands.CreateQuiz;
using ELearningApi.Core.MediatrHandlers.Quiz.Commands.UpdateQuiz;
using ELearningApi.Data.Entities;

namespace ELearningApi.Core.MediatrHandlers.Quiz;

public class QuizMappingProfile : Profile
{
    public QuizMappingProfile()
    {
        CreateMap<Data.Entities.Quiz, QuizDto>().ReverseMap();
        CreateMap<QuizQuestion, QuizQuestionDto>().ReverseMap();
        CreateMap<QuizAnswer, QuizAnswerDto>().ReverseMap();
        CreateMap<QuizQuestionMedia, QuizQuestionMediaDto>().ReverseMap();
        CreateMap<CreateQuizCommand, Data.Entities.Quiz>();
        CreateMap<UpdateQuizCommand, Data.Entities.Quiz>();

    }
}
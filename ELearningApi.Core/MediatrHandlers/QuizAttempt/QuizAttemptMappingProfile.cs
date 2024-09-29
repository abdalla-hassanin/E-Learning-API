using AutoMapper;
using ELearningApi.Data.Entities;

namespace ELearningApi.Core.MediatrHandlers.QuizAttempt;

public class QuizAttemptMappingProfile : Profile
{
    public QuizAttemptMappingProfile()
    {
        CreateMap<Data.Entities.QuizAttempt, QuizAttemptDto>();
        CreateMap<AttemptAnswer, AttemptAnswerDto>();
    }
}

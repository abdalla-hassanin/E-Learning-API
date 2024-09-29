using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizzesByLecture;

public class GetQuizzesByLectureQuery : IRequest<ApiResponse<IEnumerable<QuizDto>>>
{
    public Guid LectureId { get; set; }
}

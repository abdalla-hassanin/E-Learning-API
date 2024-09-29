using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Quiz.Queries.GetQuizzesBySection;

public class GetQuizzesBySectionQuery : IRequest<ApiResponse<IEnumerable<QuizDto>>>
{
    public Guid SectionId { get; set; }
}

using ELearningApi.Core.Base.ApiResponse;
using MediatR;

namespace ELearningApi.Core.MediatrHandlers.Section.Commands.DeleteSection;

public class DeleteSectionCommand : IRequest<ApiResponse<string>>
{
    public Guid Id { get; set; }
}

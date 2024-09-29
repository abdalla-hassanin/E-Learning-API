using AutoMapper;
using ELearningApi.Core.MediatrHandlers.Review.Commands.CreateReview;
using ELearningApi.Core.MediatrHandlers.Review.Commands.UpdateReview;

namespace ELearningApi.Core.MediatrHandlers.Review
{
    public class ReviewMappingProfile : Profile
    {
        public ReviewMappingProfile()
        {
            CreateMap<Data.Entities.Review, ReviewDto>();
            
            CreateMap<CreateReviewCommand, Data.Entities.Review>();
            CreateMap<UpdateReviewCommand, Data.Entities.Review>();

        }
    }
}
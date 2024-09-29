using AutoMapper;
using ELearningApi.Core.MediatrHandlers.Category.Commands.CreateCategory;
using ELearningApi.Core.MediatrHandlers.Category.Commands.UpdateCategory;

namespace ELearningApi.Core.MediatrHandlers.Category;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Data.Entities.Category, CategoryDto>()
            .ForMember(dest => dest.CourseCount, opt => opt.MapFrom(src => src.Courses.Count));
        CreateMap<CreateCategoryCommand, Data.Entities.Category>();
        CreateMap<UpdateCategoryCommand, Data.Entities.Category>();
    }
}


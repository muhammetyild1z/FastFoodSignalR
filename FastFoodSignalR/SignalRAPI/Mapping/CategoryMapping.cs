using AutoMapper;
using FastFoodSignalR.DtoLayer.CategoryDto;
using FastFoodSignalR.Entity.Entities;

namespace SignalRAPI.Mapping
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Category,GetCategoryDto>().ReverseMap();
            CreateMap<Category,ResultCategoryDto>().ReverseMap();
        }
    }
}

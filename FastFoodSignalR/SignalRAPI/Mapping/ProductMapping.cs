using AutoMapper;
using FastFoodSignalR.DtoLayer.ProductDto;
using FastFoodSignalR.Entity.Entities;

namespace SignalRAPI.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<Product,UpdateProductDto>().ReverseMap(); 
            CreateMap<Product,GetProductDto>().ReverseMap(); 
            CreateMap<Product,ResultProductDto>().ReverseMap(); 
            CreateMap<Product,CreateProductDto>().ReverseMap(); 
            CreateMap<Product, ProductListWithCategory>().ReverseMap(); 
        }
    }
}

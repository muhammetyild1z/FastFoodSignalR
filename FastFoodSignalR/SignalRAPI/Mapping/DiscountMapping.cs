using AutoMapper;
using FastFoodSignalR.DtoLayer.DiscountDto;
using FastFoodSignalR.Entity.Entities;

namespace SignalRAPI.Mapping
{
    public class DiscountMapping:Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();   
            CreateMap<Discount, GetDiscountDto>().ReverseMap();   
            CreateMap<Discount, ResultDiscountDto>().ReverseMap();   
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();   
        }
    }
}

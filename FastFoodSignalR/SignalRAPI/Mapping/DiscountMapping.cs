using AutoMapper;
using FastFoodSignalR.DtoLayer.ContactDto;
using FastFoodSignalR.Entity.Entities;

namespace SignalRAPI.Mapping
{
    public class DiscountMapping:Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount,UpdateContactDto>().ReverseMap();   
            CreateMap<Discount,CreateContactDto>().ReverseMap();   
            CreateMap<Discount,GetContactDto>().ReverseMap();   
            CreateMap<Discount,ResultContactDto>().ReverseMap();   
        }
    }
}

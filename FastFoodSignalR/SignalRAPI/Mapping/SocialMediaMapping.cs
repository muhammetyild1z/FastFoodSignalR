using AutoMapper;
using FastFoodSignalR.DtoLayer.SocialMediaDto;
using FastFoodSignalR.Entity.Entities;

namespace SignalRAPI.Mapping
{
    public class SocialMediaMapping:Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia,CreateSocialMediaDto>().ReverseMap(); 
            CreateMap<SocialMedia,GetSocialMediaDto>().ReverseMap(); 
            CreateMap<SocialMedia,ResultSocialMediaDto>().ReverseMap(); 
            CreateMap<SocialMedia,UpdateSocialMediaDto>().ReverseMap(); 
        }
    }
}

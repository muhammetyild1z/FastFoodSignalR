using AutoMapper;
using FastFoodSignalR.DtoLayer.FeatureDto;
using FastFoodSignalR.Entity.Entities;

namespace SignalRAPI.Mapping
{
    public class FeatureMapping:Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature,UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature,GetFeatureDto>().ReverseMap();
            CreateMap<Feature,ResultFeatureDto>().ReverseMap();
            CreateMap<Feature,CreateFeatureDto>().ReverseMap();
        }
    }
}

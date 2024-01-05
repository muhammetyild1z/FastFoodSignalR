using AutoMapper;
using FastFoodSignalR.DtoLayer.SliderDto;
using FastFoodSignalR.Entity.Entities;

namespace SignalRAPI.Mapping
{
    public class SliderMapping:Profile
    {

        public SliderMapping()
        {
            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            CreateMap<Slider, ResultSliderDto>().ReverseMap();
            CreateMap<Slider, UpdateSliderDto>().ReverseMap();
        }

    }
}

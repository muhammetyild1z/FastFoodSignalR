using AutoMapper;
using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DtoLayer.SliderDto;
using FastFoodSignalR.Entity.Entities;
using Microsoft.AspNetCore.Mvc;


namespace SignalRAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet("SliderList")]
        public IActionResult SliderList()
        {
           
           // return Ok(_mapper.Map<ResultSliderDto>(_sliderService.TGetListAll()));
            return Ok(_sliderService.TGetListAll().Take(2));
        }

        [HttpPost("SliderCreate")]
        public IActionResult SliderCreate(CreateSliderDto createSliderDto)
        {
            if (createSliderDto!=null)
            {
                _sliderService.TAdd(_mapper.Map<Slider>(createSliderDto));
                return Ok("ekleme Basarili");
            }
            else
            {
                return NotFound();
            }
           
        }

        [HttpDelete("SliderDelete")]
        public IActionResult SliderDelete(int id)
        {
             
            if (id>0)
            {
                _sliderService.TDelete(_sliderService.TGetById(id));
                return Ok();
            }
            else
            {
                return NotFound();
            }
         
        }

        [HttpPost("SliderUpdate")]
        public IActionResult SliderUpdate(UpdateSliderDto updateSliderDto)
        {
            if (updateSliderDto!=null)
            {
                var unchangedSlider = _sliderService.TGetById(updateSliderDto.SliderID);
                _sliderService.Update(_mapper.Map<Slider>(updateSliderDto), unchangedSlider);
                return Ok();
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}

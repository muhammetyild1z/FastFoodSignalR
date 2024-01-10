using AutoMapper;
using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DtoLayer.FeatureDto;
using FastFoodSignalR.DtoLayer.SocialMediaDto;
using FastFoodSignalR.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet("ListSocialMedia")]
        public IActionResult ListSocialMedia()
        {
            var values = _socialMediaService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("GetByIdSocialMedia")]
        public IActionResult GetByIdSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            return Ok(value);
        }

        [HttpPost("CreateSocialMedia")]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            _socialMediaService.TAdd(_mapper.Map<SocialMedia>(createSocialMediaDto));
            return Ok("Ekleme Basarili..");
        }

        [HttpPut("UpdateSocialMedia")]
        public IActionResult UpdateSocialMedia(int id, UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value = _socialMediaService.TGetById(id);
            _socialMediaService.Update(_mapper.Map<SocialMedia>(updateSocialMediaDto), value);
            return Ok();
        }

        [HttpDelete("DeleteSocialMedia")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(value);
            return Ok("Silme Basarili");
        }
    }
}

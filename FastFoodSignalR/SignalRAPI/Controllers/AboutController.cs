using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DtoLayer.AboutDto;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAPI.Controllers
{
    public class AboutController : Controller
    {

        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            _aboutService.TAdd(_aboutService);
            return Ok("Ekleme Basarili..");
        }
        [HttpPut]
        public IActionResult UpdateAbout(int id , UpdateAboutDto updateAboutDto)
        {
            var value=_aboutService.TGetById(id);
            _aboutService.Update(updateAboutDto, value);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        { 
            var value= _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Silme Basarili");
        }
        [HttpGet("GetByIdAbout")]
        public IActionResult GetByIdAbout(int id)
        {
            var value=_aboutService.TGetById(id);
            return Ok(value);
        }
    }
}

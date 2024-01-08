using AutoMapper;
using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DtoLayer.SocialMediaDto;
using FastFoodSignalR.DtoLayer.TestimonialDto;
using FastFoodSignalR.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet("ListTestimonial")]
        public IActionResult ListTestimonial()
        {
            var values = _testimonialService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("GetByIdTestimonial")]
        public IActionResult GetByIdTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }

        [HttpPost("CreateTestimonial")]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(_mapper.Map<Testimonial>(createTestimonialDto));
            return Ok("Ekleme Basarili..");
        }

        [HttpPut("UpdateTestimonial")]
        public IActionResult UpdateTestimonial(int id, UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.Update(_mapper.Map<Testimonial>(updateTestimonialDto), value);
            return Ok();
        }

        [HttpDelete("DeleteTestimonial")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Silme Basarili");
        }
    }
}

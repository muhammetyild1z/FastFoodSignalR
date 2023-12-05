using AutoMapper;
using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DtoLayer.ContactDto;
using FastFoodSignalR.DtoLayer.DiscountDto;
using FastFoodSignalR.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAPI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet("ListDiscount")]
        public IActionResult ListDiscount()
        {
            var values = _discountService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("GetByIdDiscount")]
        public IActionResult GetByIdDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            return Ok(value);
        }

        [HttpPost("CreateDiscount")]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            _discountService.TAdd(_mapper.Map<Discount>(createDiscountDto));
            return Ok("Ekleme Basarili..");
        }

        [HttpPut("UpdateDiscount")]
        public IActionResult UpdateDiscount(int id, UpdateDiscountDto updateDiscountDto)
        {
            var value = _discountService.TGetById(id);
            _discountService.Update(_mapper.Map<Discount>(updateDiscountDto), value);
            return Ok();
        }

        [HttpDelete("DeleteDiscount")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("Silme Basarili");
        }
    }
}

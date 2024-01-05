using AutoMapper;
using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DtoLayer.ContactDto;
using FastFoodSignalR.DtoLayer.DiscountDto;
using FastFoodSignalR.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SignalRAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper, IProductService productService)
        {
            _discountService = discountService;
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("ListDiscount")]
        public IActionResult ListDiscount()
        {
                 
            return Ok(_productService.TGetIncludeProductWithCategory());
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
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var value = _discountService.TGetById(updateDiscountDto.DiscountID);
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

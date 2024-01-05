using AutoMapper;
using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DtoLayer.OrderDto;
using FastFoodSignalR.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrderController(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }
        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            var values = _orderService.TTotalOrderCount();
            return Ok(values);
        }

        [HttpGet("TotalAktiveOrder")]
        public IActionResult TotalAktiveOrder()
        {
            var values = _orderService.TTotalAktiveOrder();
            return Ok(values);
        }

        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            var values = _orderService.TLastOrderPrice();
            return Ok(values);
        }

        [HttpGet("TodayEarning")]
        public IActionResult TodayEarning()
        {
            var values = _orderService.TTodayEarning();
            return Ok(values);
        }

        [HttpGet("TableOrderCount")]
        public IActionResult TableOrderCount()
        {
            var values = _orderService.TTableOrderCount();
            return Ok(values);
        }

        [HttpGet("OrderList")]
        public IActionResult OrderList()
        {
            var values = _orderService.TGetListAll();
            return Ok(values);
        }

        [HttpPut("OrderUpdate")]
        public IActionResult OrderUpdate(OrderUpdateDto orderUpdateDto)
        {
            var order = _orderService.TGetById(orderUpdateDto.OrderID);
             _orderService.Update(_mapper.Map<Order>(orderUpdateDto), order);
            return Ok();
        }

        [HttpGet("GetByIdBooking/{id}")]
        public IActionResult GetByIdBooking(int id)
        {
            var value = _orderService.TGetById(id);
            return Ok(value);
        }
    }
}

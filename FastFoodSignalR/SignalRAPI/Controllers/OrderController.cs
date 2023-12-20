using AutoMapper;
using FastFoodSignalR.BusinessLayer.Abstract;
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

        [HttpGet("CaseSumPrice")]
        public IActionResult CaseSumPrice()
        {
            var values = _orderService.TCaseSumPrice();
            return Ok(values);
        }

        [HttpGet("TableOrderCount")]
        public IActionResult TableOrderCount()
        {
            var values = _orderService.TTableOrderCount();
            return Ok(values);
        }

        

    }
}

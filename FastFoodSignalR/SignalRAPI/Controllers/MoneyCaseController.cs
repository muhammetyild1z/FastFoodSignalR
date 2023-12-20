using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DataAccessLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCaseController : Controller
    {
        private readonly IMoneyCaseService _moneyCaseService;

        public MoneyCaseController(IMoneyCaseService moneyCaseService)
        {
            _moneyCaseService = moneyCaseService;
        }

        [HttpGet("TodayEarning")]
        public IActionResult TodayEarning()
        {
            var values = _moneyCaseService.TTodayEarning();
            return Ok(values);
        }
    }
}

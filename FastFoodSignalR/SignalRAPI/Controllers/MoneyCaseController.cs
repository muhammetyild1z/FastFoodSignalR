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

        [HttpGet("CaseSumPrice")]
        public IActionResult CaseSumPrice()
        {
            var values = _moneyCaseService.TCaseSumPrice();
            return Ok(values);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace FastFoodUI.Areas.Admin.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}

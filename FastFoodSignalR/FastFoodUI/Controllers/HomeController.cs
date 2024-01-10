using FastFoodUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FastFoodUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        public HomeController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7088/api/Booking/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Reservation()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Reservation(CreateBookingDto createBookingDto)
        {
            var jsonData= JsonConvert.SerializeObject(createBookingDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _httpClient.PostAsync("CreateBooking", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                ViewBag.bookingSuccess = "Rezervasyon Basariyla Oluşturuldu";
                return View();
            }
            return View();
        }
    }
}

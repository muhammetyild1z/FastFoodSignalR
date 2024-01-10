using FastFoodUI.Dtos.AboutDtos;
using FastFoodUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace FastFoodUI.Areas.Admin.Controllers
{
    public class BookingController : Controller
    {
        // private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public BookingController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7088/api/Booking/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        [HttpGet]
        public async Task<IActionResult> ListBooking()
        {

            HttpResponseMessage responseMessage = await _httpClient.GetAsync("ListBooking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            else
            {
                ViewBag.ErrorMessage = "Hata";
            }
            return View();
        }
        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        public async Task<IActionResult> GetByIdBooking(int id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"GetByIdBooking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultBookingDto>(jsonData);
                return View(value);
            }
            else
            {
                ViewBag.ErrorMessage = "Hata";
            }
            return View();
        }
        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }
        [Area("Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent httpContent = new StringContent(jsonData);
            HttpResponseMessage responseMessage = await _httpClient.PostAsync("CreateBooking", httpContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                RedirectToAction("ListBooking");
            }
            else
            {
                ViewBag.ErrorMessage = "hata";
            }
            return View();
        }
        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        [HttpGet]
        public IActionResult UpdateBooking(int id)
        {
            return View();
        }
        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        [HttpPost]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            return View();
        }
        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        [HttpDelete]
        public IActionResult DeleteBooking()
        {
            return View();
        }



    }
}

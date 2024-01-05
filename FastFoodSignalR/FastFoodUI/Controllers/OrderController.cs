using FastFoodUI.Dtos.OrderDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace FastFoodUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly HttpClient _httpClient;


        public OrderController()
        {


            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7088/api/Order/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("OrderList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var orderList = JsonConvert.DeserializeObject<List<OrderResult>>(jsonData);
                return View(orderList);
            }

            return View(null);

        }

        [HttpGet]
        public async Task<IActionResult> OrderUpdate(int id)
        {

            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"GetByIdBooking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var order = JsonConvert.DeserializeObject<OrderResult>(jsonData);
                return View(order);
            }
            return View(null);

        }

        [HttpPost]
        public async Task<IActionResult> OrderUpdate(OrderUpdateDto orderUpdateDto)
        {
            var jsonData= JsonConvert.SerializeObject(orderUpdateDto);
            StringContent httpContent = new StringContent(jsonData, Encoding.UTF8);
            var responseMessage = _httpClient.PutAsync("OrderUpdate", httpContent);
            if (responseMessage.IsCompleted)
            {
                return RedirectToAction("Index");
            }
            return View(null);
        }
    }

 
}


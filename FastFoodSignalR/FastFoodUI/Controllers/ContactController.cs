using FastFoodUI.Dtos.ContactDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FastFoodUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7088/api/Contact/GetByIdContact/{1}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);
                return View(value);
            }
            else
            {
                ViewBag.ErrorMessage = "Hata..";
                return View();
            }

        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7088/api/Contact/GetByIdContact/{1}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);
                return View(value);
            }
            else
            {
                ViewBag.ErrorMessage = "Hataa.";
                return View();
            }
        }


        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {

            var client = _httpClientFactory.CreateClient();
            var unchange = await client.GetAsync($"https://localhost:7088/api/Contact/GetByIdContact/{updateContactDto.ContactID}");
            var jsonData = JsonConvert.SerializeObject(unchange);
            StringContent httpContext = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7088/api/Contact/UpdateContacy/{updateContactDto.ContactID}", httpContext);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Hataa.";
                return View();
            }
        }

    }
}

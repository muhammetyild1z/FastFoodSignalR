using FastFoodUI.Dtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace FastFoodUI.Areas.Admin.Controllers
{

    public class AboutController : Controller
    {

        private readonly IHttpClientFactory _httpsClient;


        public AboutController(IHttpClientFactory httpsClient)
        {
            _httpsClient = httpsClient;
        }

        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        public async Task<IActionResult> ListAbout()
        {
            var client = _httpsClient.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7088/api/About/");
            var responseMessage = await client.GetAsync("ListAbout");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            else
            {
                ViewBag.ErrorMessage = "Islem Basarisiz..";
                return View();
            }

        }
        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var client = _httpsClient.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7088/api/Product/DeleteAbout/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ListAbout");
            }
            else
            {

                ViewBag.ErrorMessage = "Silme işlemi başarısız oldu.";
                return View();
            }
        }
        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpsClient.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7088/api/About/GetByIdAbout/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                return View(value);
            }
            else
            {
                ViewBag.ErrorMessage = "'islem basarisiz..";
                return View();
            }
        }
        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAbout)
        {
            var client = _httpsClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAbout);
            StringContent httpContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync($"https://localhost:7088/api/About/UpdateAbout/{updateAbout.AboutID}", httpContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ListAbout");
            }
            else
            {
                ViewBag.ErrorMessage = "Guncelleme basarisiz oldu..";
                return View();
            }
        }
    }
}

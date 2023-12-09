using FastFoodUI.Dtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FastFoodUI.Controllers
{
    public class AboutController : Controller
    {

        private readonly IHttpClientFactory _httpsClient;

        public AboutController(IHttpClientFactory httpsClient)
        {
            _httpsClient = httpsClient;
        }

        public async  Task<IActionResult> ListAbout()
        {
            var client= _httpsClient.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7088/api/Product/");
            var responseMessage = await client.GetAsync("ListAbout");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData =await responseMessage.Content.ReadAsStringAsync();
                var values= JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

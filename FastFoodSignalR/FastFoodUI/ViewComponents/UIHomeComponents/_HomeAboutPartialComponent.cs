using FastFoodUI.Dtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FastFoodUI.ViewComponents.UIndexComponents
{
    public class _HomeAboutPartialComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;
        public _HomeAboutPartialComponent()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7088/api/About/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task< IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage resposenMessage = await _httpClient.GetAsync("ListAbout");
            if (resposenMessage.IsSuccessStatusCode)
            {
                var jsonData= await resposenMessage.Content.ReadAsStringAsync();
                var about = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(about);
            }
            return View("Not Found");
        }
    }
}


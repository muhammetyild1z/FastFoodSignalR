using FastFoodUI.Dtos.SocialMediaDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FastFoodUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooterSocialMediaPartialComponent:ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _UILayoutFooterSocialMediaPartialComponent()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7088/api/SocialMedia/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task <IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("ListSocialMedia");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var socialMedia= JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
                return View(socialMedia);
            }
            return View("Not Found");
        }
    }
}

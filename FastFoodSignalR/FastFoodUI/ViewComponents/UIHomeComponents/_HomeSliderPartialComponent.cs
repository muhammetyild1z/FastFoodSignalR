using FastFoodUI.Dtos.SliderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace FastFoodUI.ViewComponents.UIndexComponents
{
    public class _HomeSliderPartialComponent:ViewComponent
    {
        private readonly HttpClient _httpClient;
        public _HomeSliderPartialComponent()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7088/api/Slider/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        } 
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMessage = await _httpClient.GetAsync("SliderList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                
                var slider = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
                return View( slider );
            }

            return View( "Not Found");
        }
    }
}

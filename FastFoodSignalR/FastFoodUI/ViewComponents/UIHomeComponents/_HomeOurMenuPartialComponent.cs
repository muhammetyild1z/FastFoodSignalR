using FastFoodUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FastFoodUI.ViewComponents.UIndexComponents
{
    public class _HomeOurMenuPartialComponent:ViewComponent
    {
        private readonly HttpClient _httpClient;
        public _HomeOurMenuPartialComponent()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7088/api/Product/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage responseMessage =await _httpClient.GetAsync("ListProduct");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var menu = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);
                return View(menu);
            }
            else
            {
                ViewBag.MenuErr = "Not Found";
                return View();
            }
         
        }
    }
}

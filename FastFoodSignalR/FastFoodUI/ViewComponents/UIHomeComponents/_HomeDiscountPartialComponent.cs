using FastFoodUI.Dtos.DiscountDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FastFoodUI.ViewComponents.UIndexComponents
{
    public class _HomeDiscountPartialComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;
        public _HomeDiscountPartialComponent()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7088/api/Discount/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task< IViewComponentResult> InvokeAsync()
        {
            var responseMessage = await _httpClient.GetAsync("ListDiscount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var discounts = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
                return View(discounts);
            }
            else
            {
                ViewBag.NotDiscount = "Not Found";
                return View();
            }
          
        }
    }
}

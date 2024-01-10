using FastFoodUI.Dtos.ContactDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FastFoodUI.ViewComponents.UILayoutComponents
{
    public class _UIFooterPartialComponent : ViewComponent
    {

        private readonly HttpClient _httpClient;

        public _UIFooterPartialComponent()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7088/api/Contact/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
           
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("GetByIdContact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var footer = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);
                return View(footer);
            }
            return View("Not Found");
        }
    }

}

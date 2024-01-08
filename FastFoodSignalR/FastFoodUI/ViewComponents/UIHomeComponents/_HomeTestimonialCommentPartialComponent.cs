using FastFoodUI.Dtos.TestimonialDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FastFoodUI.ViewComponents.UIndexComponents
{
    public class _HomeTestimonialCommentPartialComponent:ViewComponent
    {
        private readonly HttpClient _httpClient;
        public _HomeTestimonialCommentPartialComponent()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7088/api/Testimonial/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task< IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("ListTestimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var testimonial = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(testimonial);
            }
            return View("Not Found");
        }
    }
}

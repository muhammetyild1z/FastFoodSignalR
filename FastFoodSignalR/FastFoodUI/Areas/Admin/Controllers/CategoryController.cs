using FastFoodUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace FastFoodUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7088/api/Category/ListCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7088/api/Category/CreateCategory", stringContent);
            //client.BaseAddress = new  Uri("https://localhost:7088/");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var errorResponse = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine("Hata: " + errorResponse);


            }
            return View();

        }
        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7088/api/Category/DeleteCategory/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
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
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7088/api/Category/GetByIdCategory/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var unchange = await client.GetAsync($"https://localhost:7088/api/Category/GetByIdCategory/{updateCategoryDto.CategoryID}");
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent httpContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7088/api/Category/UpdateCategory/{updateCategoryDto.CategoryID}", httpContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}

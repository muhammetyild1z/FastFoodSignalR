using FastFoodSignalR.BusinessLayer.Concrate;
using FastFoodSignalR.DataAccessLayer.Concrate;
using FastFoodSignalR.DataAccessLayer.EntityFramework;
using FastFoodSignalR.Entity.Entities;
using FastFoodUI.Dtos.CategoryDtos;
using FastFoodUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FastFoodUI.Areas.Admin.Controllers
{

    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;

        }

        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        [HttpGet]
        public async Task<IActionResult> ListProduct()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7088/api/Product/");
            var responseMessage = await client.GetAsync("ListProduct");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7088/api/Category/ListCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var category = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                ViewBag.Category = category.Select(x => new { x.CategoryName, x.CategoryID });
                return View();
            }
            return View();
        }
        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7088/api/Product/");
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent httpContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("CreateProduct", httpContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ListProduct");
            }
            return View();
        }

        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7088/api/Product/DeleteProduct/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ListProduct");
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
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var clientCat = _httpClientFactory.CreateClient();
            var responseMessageCat = await clientCat.GetAsync("https://localhost:7088/api/Category/ListCategory");
            if (responseMessageCat.IsSuccessStatusCode)
            {
                var jsonDataCat = await responseMessageCat.Content.ReadAsStringAsync();
                var category = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonDataCat);
                ViewBag.Category = category.Select(x => new { x.CategoryName, x.CategoryID });

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri("https://localhost:7088/api/Product/");
                var responseMessage = await client.GetAsync($"GetByIdProduct/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                    return View(value);
                }
            }
            return View();
        }
        [Area("Admin")]
        [Route("[controller]/[action]/{id?}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var clientCat = _httpClientFactory.CreateClient();
            var responseMessageCat = await clientCat.GetAsync("https://localhost:7088/api/Category/ListCategory");
            if (responseMessageCat.IsSuccessStatusCode)
            {
                var jsonDataCat = await responseMessageCat.Content.ReadAsStringAsync();
                var category = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonDataCat);
                ViewBag.Category = category.Select(x => new { x.CategoryName, x.CategoryID });
                //Update
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri("https://localhost:7088/api/Product/");
                var jsonData = JsonConvert.SerializeObject(updateProductDto);
                StringContent httpContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync($"UpdateProduct/{updateProductDto.ProductID}", httpContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListProduct");
                }
            }
            return View();
        }
    }
}

using FastFoodSignalR.BusinessLayer.Concrate;
using FastFoodSignalR.DataAccessLayer.Concrate;
using FastFoodSignalR.DataAccessLayer.EntityFramework;
using FastFoodSignalR.Entity.Entities;

using FastFoodUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FastFoodUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        

        public ProductController(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;

        }

        //public async Task<IActionResult> ProductList()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    client.BaseAddress = new Uri("https://localhost:7088/api/CategoryAndProduct/");

        //    var responseMessage = await client.GetAsync("GetProductWithCategory");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<List<ResultCategoryAndProductDto>>(jsonData);

        //        return View(values);
        //    }


        //    return View();
        //}
        [HttpGet]
        public async Task<IActionResult> CreateProduct(int id)
        {
            var client= _httpClientFactory.CreateClient();
            return View();
        }
    }
}

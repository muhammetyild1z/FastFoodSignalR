using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodUI.Dtos.AccountDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FastFoodUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;

        public AccountController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7088/api/Account/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            var jsonData= JsonConvert.SerializeObject(signInDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _httpClient.PostAsync("SignIn", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return NotFound("404");
        }
        [HttpGet]
        public IActionResult SignUp()
        {

            return View();
        }
        [HttpPost]
        public async Task< IActionResult >SignUp(SignUpDto signUpDto)
        {
           
            var jsonData= JsonConvert.SerializeObject(signUpDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _httpClient.PostAsync("SignUp", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                ViewBag.UserCreateSuccess = "Basariyla Kayit oldunuz";
                return RedirectToAction("SignIn");
            }
            return NotFound( "Kayit Basarisiz");
        }

        public IActionResult SignOut()
        {
            return View();
        }
    }
}

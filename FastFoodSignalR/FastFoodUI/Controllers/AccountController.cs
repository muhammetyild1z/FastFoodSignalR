using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodUI.Dtos.AccountDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Net;
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
                ViewBag.UserSignInMessageSuccess = "Giris Basarili Yonlendiriliyorusunuz..";
                return View();
            }
            else if (responseMessage.StatusCode== HttpStatusCode.Unauthorized)
            {
                ViewBag.UserSignInMessageErr = "Kullanici Adi Veya Sifre Hatali";
                return View();
            }
           
            return View("Bir Hatayla Karşılaşıldı Yetkiliyle İletişime geçin..");
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
            if (signUpDto.UserPhoneNumber.Length!=10)
            {
                ViewBag.UserNumber = "10 karakter girin (5xx xxx xx xx)";
                return View();
            }
            if (responseMessage.IsSuccessStatusCode)
            {
                ViewBag.UserCreateSuccess = "Kayit Basarili Giris Ekranina Yonlendiriliyorsunuz..";
                return View();
            }
          
            else if (responseMessage.StatusCode == HttpStatusCode.BadRequest)
            {
                ViewBag.UserCreateMail = "Bu Mail Adresi Daha Once Kullanilmis";
                return View();
            }
            else if(responseMessage.StatusCode== HttpStatusCode.InternalServerError)
            {
                ViewBag.UserCreateUser = "Bu Kullanici Adi Daha Once Alinmis.";
                return View(signUpDto);
                }
           
            else
            {
                return View() ;
            }
           
           
        } 

        public IActionResult SignOut()
        {
            return View();
        }
    }
}

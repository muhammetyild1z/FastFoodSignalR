using Microsoft.AspNetCore.Mvc;

namespace FastFoodUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
      
    }
}

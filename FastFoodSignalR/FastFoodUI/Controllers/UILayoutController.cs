using Microsoft.AspNetCore.Mvc;

namespace FastFoodUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}

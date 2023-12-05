using Microsoft.AspNetCore.Mvc;

namespace FastFoodUI.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}

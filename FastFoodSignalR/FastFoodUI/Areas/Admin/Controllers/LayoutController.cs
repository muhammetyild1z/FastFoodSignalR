using Microsoft.AspNetCore.Mvc;

namespace FastFoodUI.Areas.Admin.Controllers
{
    public class LayoutController : Controller
    {
        [Area("Admin")]
        
        public IActionResult Layout()
        {
            return View();
        }
    }
}

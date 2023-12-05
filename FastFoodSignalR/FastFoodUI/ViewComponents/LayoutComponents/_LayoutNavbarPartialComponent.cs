using Microsoft.AspNetCore.Mvc;

namespace FastFoodUI.ViewComponents.LayoutComponents
{
    public class _LayoutNavbarPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

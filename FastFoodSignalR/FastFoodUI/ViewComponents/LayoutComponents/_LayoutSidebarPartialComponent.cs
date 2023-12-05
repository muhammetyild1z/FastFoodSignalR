using Microsoft.AspNetCore.Mvc;

namespace FastFoodUI.ViewComponents.LayoutComponents
{
    public class _LayoutSidebarPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

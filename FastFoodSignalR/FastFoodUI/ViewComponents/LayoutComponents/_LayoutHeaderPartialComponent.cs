using Microsoft.AspNetCore.Mvc;

namespace FastFoodUI.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace FastFoodUI.ViewComponents.UILayoutComponents
{
    public class _UIFooterPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

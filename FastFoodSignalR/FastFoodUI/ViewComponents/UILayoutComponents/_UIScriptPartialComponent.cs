using Microsoft.AspNetCore.Mvc;

namespace FastFoodUI.ViewComponents.UILayoutComponents
{
    public class _UIScriptPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

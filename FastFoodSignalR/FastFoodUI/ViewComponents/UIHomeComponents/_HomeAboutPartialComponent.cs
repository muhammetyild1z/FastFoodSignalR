using Microsoft.AspNetCore.Mvc;
namespace FastFoodUI.ViewComponents.UIndexComponents
{
    public class _HomeAboutPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

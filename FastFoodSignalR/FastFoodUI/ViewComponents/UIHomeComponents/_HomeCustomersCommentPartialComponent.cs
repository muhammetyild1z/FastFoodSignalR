using Microsoft.AspNetCore.Mvc;

namespace FastFoodUI.ViewComponents.UIndexComponents
{
    public class _HomeCustomersCommentPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

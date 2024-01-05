using Microsoft.AspNetCore.Mvc;

namespace FastFoodUI.ViewComponents.UILayoutComponents
{
    public class _UIHeaderPartialComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;

namespace FastFoodUI.ViewComponents.LayoutComponents
{
    public class _LayoutScriptPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

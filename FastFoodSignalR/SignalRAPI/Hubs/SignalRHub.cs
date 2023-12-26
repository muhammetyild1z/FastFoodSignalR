using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DataAccessLayer.Concrate;
using Microsoft.AspNetCore.SignalR;

namespace SignalRAPI.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCase;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCase)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCase = moneyCase;
        }

        public async Task SendCategory()
        {
            var categoryCount = _categoryService.TGetListAll().Count();
            var productAktiveCount = _categoryService.TAktiveCategoryCount();
            var productPassiveCount = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);
            await Clients.All.SendAsync("ReceiveAktiveProductCount", productAktiveCount);
            await Clients.All.SendAsync("ReceivePassiveProductCount", productPassiveCount);
        }


        public async Task SendProduct()
        {
            var productCount = _productService.TGetListAll().Count();
            var AVGproductPrice = _productService.TProductPriceAVG();
            var MaxproductPrice = _productService.TProductPriceMax();
            var MinproductPrice = _productService.TProductPriceMin();
            var AVGHamburgerPrice = _productService.THamburgerPriceAVG();
            await Clients.All.SendAsync("ReceiveProductCount", productCount);
            await Clients.All.SendAsync("ReceiveAVGproductPrice", AVGproductPrice);
            await Clients.All.SendAsync("ReceiveMaxproductPrice", MaxproductPrice.Item1, MaxproductPrice.Item2);
            await Clients.All.SendAsync("ReceiveMinproductPrice", MinproductPrice.Item1, MinproductPrice.Item2);
            await Clients.All.SendAsync("ReceiveAVGHamburgerPrice", AVGHamburgerPrice);
        }

        public async Task SendOrder()
        {
            var totalOrderCount= _orderService.TTotalOrderCount();
            var lastOrderPrice = _orderService.TLastOrderPrice();
            var aktiveOrderCount = _orderService.TTotalAktiveOrder();
            var tableCount = _orderService.TTableOrderCount();
            var todayEarnig = _orderService.TTodayEarning();


            await Clients.All.SendAsync("ReceiveTotalOrder", totalOrderCount);
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderPrice);
            await Clients.All.SendAsync("ReceiveAktiveOrderCount", aktiveOrderCount);
            await Clients.All.SendAsync("ReceiveTableCount", tableCount);
            await Clients.All.SendAsync("ReceiveTodayEarnig", todayEarnig);
        }
            
        public async Task SendCase()
        {
            
            var todayEarnig = _moneyCase.TCaseSumPrice();

            await Clients.All.SendAsync("ReceiveTotalCase", todayEarnig);
        }
    }
}

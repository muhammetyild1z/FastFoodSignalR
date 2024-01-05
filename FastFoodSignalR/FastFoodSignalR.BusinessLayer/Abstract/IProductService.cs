using FastFoodSignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetListDiscountIncludeProduct();
        List<Product> TGetIncludeProductWithCategory();
      
        Product TGetProductById(int id);

        decimal TProductPriceAVG();
        (decimal, string) TProductPriceMax();
        (decimal, string) TProductPriceMin();
        decimal THamburgerPriceAVG();


    }
}

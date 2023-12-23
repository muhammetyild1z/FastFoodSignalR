using FastFoodSignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetIncludeProductWithCategory();
        int ProductCount();
        decimal ProductPriceAVG();
        (decimal, string) ProductPriceMax();
        (decimal, string) ProductPriceMin();
        decimal HamburgerPriceAVG();
    }
}

using FastFoodSignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.BusinessLayer.Abstract
{
    public interface ICategoryAndProductService:IGenericService<CategoryAndProduct>
    {
        List<CategoryAndProduct> TGetProductWithCategories();
        CategoryAndProduct TGetCategoryById(int id);
    }
}

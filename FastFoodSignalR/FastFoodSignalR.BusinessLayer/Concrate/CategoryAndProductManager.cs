using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DataAccessLayer.Abstract;
using FastFoodSignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.BusinessLayer.Concrate
{
    public class CategoryAndProductManager : ICategoryAndProductService
    {
        private readonly ICategoryAndProductDal _CategoryAndProduct;

        public CategoryAndProductManager(ICategoryAndProductDal categoryAndProduct)
        {
            _CategoryAndProduct = categoryAndProduct;
        }

        public void TAdd(CategoryAndProduct entity)
        {
            _CategoryAndProduct.Add(entity);
        }

        public void TDelete(CategoryAndProduct entity)
        {
            _CategoryAndProduct.Delete(entity);
        }

        public CategoryAndProduct TGetById(int Id)
        {
          return _CategoryAndProduct.GetById(Id);
        }

        public CategoryAndProduct TGetCategoryById(int id)
        {
            return _CategoryAndProduct.GetListAll().Where(x => x.ProductID == id).FirstOrDefault();
        }
        public List<CategoryAndProduct> TGetListAll()
        {
            return _CategoryAndProduct.GetListAll();
        }

        public List<CategoryAndProduct> TGetProductWithCategories()
        {
           return _CategoryAndProduct.GetProductWithCategories();
        }

        public void Update(CategoryAndProduct entity, CategoryAndProduct unchanged)
        {
            _CategoryAndProduct.Update(entity, unchanged);
        }
    }
}

using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DataAccessLayer.Abstract;
using FastFoodSignalR.DataAccessLayer.Concrate;
using FastFoodSignalR.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.BusinessLayer.Concrate
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
       
       
        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

       

        public Product TGetById(int Id)
        {
            return _productDal.GetById(Id);
        }

        public List<Product> TGetIncludeProductWithCategory()
        {
            return
                _productDal.GetIncludeProductWithCategory();
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

        public List<Product> TGetListDiscountIncludeProduct()
        {
            return _productDal.GetListDiscountIncludeProduct();
        }

        public Product TGetProductById(int id)
        {
          return (_productDal.GetListAll().Where(x=>x.ProductID==id).FirstOrDefault());
        }

        public decimal THamburgerPriceAVG()
        {
            return _productDal.HamburgerPriceAVG();
        }

        public decimal TProductPriceAVG()
        {
            return _productDal.ProductPriceAVG();  
        }

        public (decimal, string) TProductPriceMax()
        {
            return _productDal.ProductPriceMax();
        }

        public (decimal, string) TProductPriceMin()
        {
            return _productDal.ProductPriceMin();
        }

        public void Update(Product entity, Product unchanged)
        {
            _productDal.Update(entity, unchanged);  
        }
    }
}

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

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

        public void Update(Product entity, Product unchanged)
        {
            _productDal.Update(entity, unchanged);  
        }
    }
}

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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _category;

        public CategoryManager(ICategoryDal category)
        {
            _category = category;
        }

        public void TAdd(Category entity)
        {
            _category.Add(entity);
        }

        public void TDelete(Category entity)
        {
            _category.Delete(entity);   
        }

        public Category TGetById(int Id)
        {
            return _category.GetById(Id);
        }

        public List<Category> TGetListAll()
        {
            return _category.GetListAll();
        }

        public void Update(Category entity, Category unchanged)
        {
            _category.Update(entity, unchanged);
        }
    }
}

using FastFoodSignalR.DataAccessLayer.Abstract;
using FastFoodSignalR.DataAccessLayer.Concrate;
using FastFoodSignalR.DataAccessLayer.Repositories;
using FastFoodSignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.DataAccessLayer.EntityFramework
{
    public class efCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly FastFoodContext _fastFoodContext;
        public efCategoryDal(FastFoodContext context, FastFoodContext fastFoodContext) : base(context)
        {
            _fastFoodContext = fastFoodContext;
        }

        public int AktiveCategoryCount()
        {       
            return _fastFoodContext.Categories.Where(x => x.CategoryStatus == true).Count();
        }

        public int CategoryCount()
        {
            return _fastFoodContext.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            return _fastFoodContext.Categories.Where(x => x.CategoryStatus == false).Count();
        }
    }
}

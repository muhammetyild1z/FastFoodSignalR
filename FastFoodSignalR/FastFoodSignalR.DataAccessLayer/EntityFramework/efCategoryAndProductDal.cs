using FastFoodSignalR.DataAccessLayer.Abstract;
using FastFoodSignalR.DataAccessLayer.Concrate;
using FastFoodSignalR.DataAccessLayer.Repositories;
using FastFoodSignalR.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.DataAccessLayer.EntityFramework
{
    public class efCategoryAndProductDal : GenericRepository<CategoryAndProduct>, ICategoryAndProductDal
    {
        public efCategoryAndProductDal(FastFoodContext context) : base(context)
        {
        }
        public List<CategoryAndProduct> GetProductWithCategories()
        {
            FastFoodContext _context = new FastFoodContext();
             var v=_context.CategoryAndProducts.Include(x => x.Product).Include(x=>x.Category).ToList();
            return v;
        }
    }
}

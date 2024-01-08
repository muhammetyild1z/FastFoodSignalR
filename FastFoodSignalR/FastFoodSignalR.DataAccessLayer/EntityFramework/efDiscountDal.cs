using FastFoodSignalR.DataAccessLayer.Abstract;
using FastFoodSignalR.DataAccessLayer.Concrate;
using FastFoodSignalR.DataAccessLayer.Repositories;
using FastFoodSignalR.Entity.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.PowerBI.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FastFoodSignalR.DataAccessLayer.EntityFramework
{
    public class efDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        private readonly FastFoodContext _fastFoodContext;

        public efDiscountDal(FastFoodContext context) : base(context)
        {
            _fastFoodContext = context;

        }

        public List<Discount> GetListDiscountIncludeProduct()
        {
           return _fastFoodContext.Discounts.Include(x=>x.product).ToList();
        }
    }
}

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
    public class efMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
    {
        private readonly FastFoodContext _fastFoodContext;
        public efMoneyCaseDal(FastFoodContext context, FastFoodContext fastFoodContext) : base(context)
        {
            _fastFoodContext = fastFoodContext;
        }

        public decimal TodayEarning()
        {
            return _fastFoodContext.MoneyCases.Sum(x => x.TotalAmount);
        }


    }
}

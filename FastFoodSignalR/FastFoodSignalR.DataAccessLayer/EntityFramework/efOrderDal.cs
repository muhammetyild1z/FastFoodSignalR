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
    public class efOrderDal : GenericRepository<Order>, IOrderDal
    {
        private readonly FastFoodContext _fastFoodContext;
        public efOrderDal(FastFoodContext context, FastFoodContext fastFoodContext ) : base(context)
        {
            _fastFoodContext = fastFoodContext;
        }

        public decimal CaseSumPrice()
        {
           return _fastFoodContext.Orders.Sum(x => x.OrderTotalPrice);
        }

        public decimal LastOrderPrice()
        {
            return _fastFoodContext.Orders.OrderByDescending(x => x.OrderDateTime)
                .Select(x => x.OrderTotalPrice)
                .FirstOrDefault();
        }

        public int TableOrderCount()
        {
            return _fastFoodContext.Orders.Count();
        }

        public decimal TodayEarning()
        {
            return _fastFoodContext.Orders.Where(x=>x.OrderStatus==true)
                .Where(x => x.OrderDateTime.DayOfYear == DateTime.Today.DayOfYear)
                .Sum(x=>x.OrderTotalPrice);
        }

        public int TotalAktiveOrder()
        {
            return _fastFoodContext.Orders.Count(x => x.OrderStatus == true);
        }

        public int TotalOrderCount()
        {
            return _fastFoodContext.Orders.Count();
        }
    }
}

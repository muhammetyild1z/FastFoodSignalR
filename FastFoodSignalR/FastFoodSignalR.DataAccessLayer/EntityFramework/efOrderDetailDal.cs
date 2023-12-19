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
    public class efOrderDetailDal : GenericRepository<OrderDetail>, IOrderDetailDal
    {
        public efOrderDetailDal(FastFoodContext context) : base(context)
        {
        }
    }
}

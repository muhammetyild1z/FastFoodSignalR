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
    public class OrderDetailManager : IOrderDetailService
    {
        IOrderDetailDal _orderDetail;

        public OrderDetailManager(IOrderDetailDal orderDetail)
        {
            _orderDetail = orderDetail;
        }

        public void TAdd(OrderDetail entity)
        {
            _orderDetail.Add(entity);
        }

        public void TDelete(OrderDetail entity)
        {
            _orderDetail.Delete(entity);
        }

        public OrderDetail TGetById(int Id)
        {
            return _orderDetail.GetById(Id);
        }

        public List<OrderDetail> TGetListAll()
        {
            return _orderDetail.GetListAll();
        }

        public void Update(OrderDetail entity, OrderDetail unchanged)
        {
            _orderDetail.Update(entity, unchanged);
        }
    }
}

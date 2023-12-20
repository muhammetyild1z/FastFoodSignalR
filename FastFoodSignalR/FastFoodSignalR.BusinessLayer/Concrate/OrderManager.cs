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
    public class OrderManager : IOrderService
    {
        IOrderDal _order;

        public OrderManager(IOrderDal order)
        {
            _order = order;
        }      

        public void TAdd(Order entity)
        {
            _order.Add(entity);
        }

        public decimal TCaseSumPrice()
        {
           return _order.CaseSumPrice();
        }

        public void TDelete(Order entity)
        {
            _order.Delete(entity);
        }

        public Order TGetById(int Id)
        {
            return _order.GetById(Id);
        }

        public List<Order> TGetListAll()
        {
            return _order.GetListAll();
        }

        public decimal TLastOrderPrice()
        {
            return _order.LastOrderPrice();
        }

        public int TTableOrderCount()
        {
            return _order.TableOrderCount();
        }

        

        public int TTotalAktiveOrder()
        {
            return _order.TotalAktiveOrder();
        }

        public int TTotalOrderCount()
        {
            return _order.TotalOrderCount();
        }

        public void Update(Order entity, Order unchanged)
        {
            _order.Update(entity, unchanged);
        }
    }
}

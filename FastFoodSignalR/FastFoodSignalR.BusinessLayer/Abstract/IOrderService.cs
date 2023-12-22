using FastFoodSignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.BusinessLayer.Abstract
{
    public interface IOrderService:IGenericService<Order>
    {
        int TTotalOrderCount();
        int TTotalAktiveOrder();
        decimal TLastOrderPrice();
        decimal TTodayEarning();
        int TTableOrderCount();
        
       
    }
}

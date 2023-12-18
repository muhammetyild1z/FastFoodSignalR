using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.Entity.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public string TableNumber { get; set; }
        public string OrderDescription { get; set; }
        public DateTime OrderDateTime{ get; set; }
        public decimal OrderTotalPrice{ get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}

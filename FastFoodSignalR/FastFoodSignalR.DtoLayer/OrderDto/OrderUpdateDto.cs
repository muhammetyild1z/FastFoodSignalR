using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.DtoLayer.OrderDto
{
    public class OrderUpdateDto
    {
        public int OrderID { get; set; }
        public string TableNumber { get; set; }
        public string OrderDescription { get; set; }
        public DateTime OrderDateTime { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public bool OrderStatus { get; set; }
    }
}

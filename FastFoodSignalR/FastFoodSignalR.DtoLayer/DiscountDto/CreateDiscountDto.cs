using FastFoodSignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.DtoLayer.DiscountDto
{
    public class CreateDiscountDto
    {
        public int DiscountAmount { get; set; }
        public decimal DiscountPrice { get; set; }
              
        public DateTime DiscountOverTime { get; set; }
        public int ProductID { get; set; }
        
    }
}

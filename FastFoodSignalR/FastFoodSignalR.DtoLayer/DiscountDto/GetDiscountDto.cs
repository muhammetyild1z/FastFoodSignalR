using FastFoodSignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.DtoLayer.DiscountDto
{
    public class GetDiscountDto
    {
        public int DiscountID { get; set; }
        public int DiscountAmount { get; set; }
        public decimal DiscountPrice { get; set; }
        //public string DiscountProductDesc { get; set; }           
        public DateTime DiscountOverTime { get; set; }
        public int ProductID { get; set; }
        public Product product { get; set; }
    }
}

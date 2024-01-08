using FastFoodSignalR.Entity.Entities;

namespace FastFoodUI.Dtos.DiscountDto
{
    public class ResultDiscountDto
    {
        public int DiscountID { get; set; }
        public int DiscountAmount { get; set; }
        public decimal DiscountPrice { get; set; }
        //public string DiscountProductDesc { get; set; }           
        public DateTime DiscountOverTime { get; set; }
        public Product product { get; set; }
    }
}

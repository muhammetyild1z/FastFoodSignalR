using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace FastFoodSignalR.Entity.Entities
{
    public class Discount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiscountID { get; set; }     
        public int DiscountAmount { get; set; }
        public decimal DiscountPrice { get; set; }
        //public string DiscountProductDesc { get; set; }           
        public DateTime DiscountOverTime { get; set; }

        public int? ProductID { get; set; }
        public Product product { get; set; }
    }
}

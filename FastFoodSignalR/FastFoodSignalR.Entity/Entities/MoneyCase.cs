using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.Entity.Entities
{
    public class MoneyCase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MoneyCaseID { get; set; }
        public decimal TotalAmount { get; set; }
    }
}

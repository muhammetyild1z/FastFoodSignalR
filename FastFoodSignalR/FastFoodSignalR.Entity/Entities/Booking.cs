using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FastFoodSignalR.Entity.Entities
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookindID { get; set; }
        public string BookingName { get; set; }
        public string BookingPhone { get; set; }
        public string BookingMail { get; set; }
        public int BookingPersonCount { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingDesciption { get; set; }

    }
}

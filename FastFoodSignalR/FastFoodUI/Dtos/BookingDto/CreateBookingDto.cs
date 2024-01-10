namespace FastFoodUI.Dtos.BookingDto
{
    public class CreateBookingDto
    {
        public string BookingName { get; set; }
        public string BookingPhone { get; set; }
        public string BookingMail { get; set; }
        public string BookingDesciption { get; set; }
        public int BookingPersonCount { get; set; }
        public DateTime BookingDate { get; set; }
    }
}

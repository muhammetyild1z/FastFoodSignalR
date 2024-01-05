namespace FastFoodUI.Dtos.OrderDto
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

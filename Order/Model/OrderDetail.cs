namespace Order.Model
{
    public class OrderDetail
    {
        public int DetailId { get; set; }
        public int Quantity { get; set; }
        public string TaxStatus { get; set; }
        public int ItemId { get; set; }
        public Item item { get; set; }
    }
}

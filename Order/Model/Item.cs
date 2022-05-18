namespace OrderApp.Model
{
    public class Item
    {
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public float ShipWeight { get; set; }
        public string? Description { get; set; }
    }
}
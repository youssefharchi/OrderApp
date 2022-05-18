﻿namespace Order.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime Created { get; set; }
        public string Status { get; set; }
        public ICollection<OrderDetail> Details { get; set; }
    }
}
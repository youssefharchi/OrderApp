﻿namespace OrderApp.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        public ICollection<Model.Order>? Orders { get; set; }
    }
}
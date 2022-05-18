﻿using OrderApp.Model;

namespace OrderApp.Interfaces
{
    public interface IOrderDetailRepository
    {
        ICollection<OrderDetail> GetOrderDetail();
    }
}
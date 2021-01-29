using System;
using System.Collections.Generic;
using System.Text;

namespace AppShop.Application.Order.Commands.CreateOrder
{
    public class OrderVm
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string OrderGroup { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class OrderVmlList
    {
        public List<OrderVm> orderlist { get; set; }
        public decimal GrandTotal { get; set; }
    }
}

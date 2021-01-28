using System;
using System.Collections.Generic;
using System.Text;

namespace AppShop.Application.Order.Queries.GetOrder
{
    public class GetSalesVm
    {
        public int SalesId { get; set; }
        public string OrderGroup { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public decimal Total { get; set; }
        public string Email { get; set; }
    }
}

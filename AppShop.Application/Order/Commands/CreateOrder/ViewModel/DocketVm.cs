using System;
using System.Collections.Generic;
using System.Text;

namespace AppShop.Application.Order.Commands.CreateOrder.ViewModel
{
    public class DocketVm
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string DocketNumber { get; set; }
        public string PickUpDetails { get; set; }
        public int Qty { get; set; }
    }
}

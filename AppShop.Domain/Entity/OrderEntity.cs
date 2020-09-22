using AppShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShop.Domain.Entity
{
   public class OrderEntity : CommonEntity
    {
        public int OrderId { get; set; }
        public string OrderGroup { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

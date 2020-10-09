using AppShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShop.Domain.Entity
{
    public class SalesEntity : CommonEntity
    {
        public int SalesId { get; set; }
        public string OrderGroup { get; set; }
        public decimal Total { get; set; }
        public string InvoiceNumber { get; set; }
        public int? CustomerId { get; set; }
    }
}

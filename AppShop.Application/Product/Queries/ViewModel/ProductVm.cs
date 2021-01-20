using System;
using System.Collections.Generic;
using System.Text;

namespace AppShop.Application.Product.Queries.ViewModel
{
    public class ProductVm
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }

}

using AppShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShop.Domain.Entity
{
    public class ProductEntity : CommonEntity
    {
        public int ProductId { get; set; }
        public ProductCategoryEntity ProductCategory { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
